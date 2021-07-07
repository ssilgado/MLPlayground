using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

using MLPlayground.Services.Contracts;
using MLPlayground.Services.Extensions;
using MLPlayground.Models.Models;
using MLPlayground.Models.Constants;

namespace MLPlayground.Services.Implementations
{
    public class ImageLoadService: IImageLoadService
    {
        private readonly IImageDownloadHttpClient _imageDownloadHttpClient;

        public ImageLoadService(IImageDownloadHttpClient imageDownloadHttpClient)
        {
            _imageDownloadHttpClient = imageDownloadHttpClient;
        }
        public async Task<bool> LoadImages()
        {
            try
            {
                var imageDownloadDataList = ParseImageDataFile().ToList();
                var imageDownloadDataBatches = imageDownloadDataList.ChunkBy(10);
                var imageManifest = new List<ImageTrainingData>();

                foreach(var batch in imageDownloadDataBatches)
                {
                    var downloadImagesTask = batch.Select(o =>
                    {
                        if(!o.ImageAlreadyDownloaded) return GetImages(o);
                        return Task.FromResult(o);
                    });

                    var loadedImageDownloadDataList = await Task.WhenAll(downloadImagesTask);

                    var validImageNetDataList = loadedImageDownloadDataList.Where(o => o.Image != null);
                    var preExistingImages = loadedImageDownloadDataList.Where(o => o.ImageAlreadyDownloaded);

                    foreach(var imageDownloadData in validImageNetDataList)
                    {
                        var imageSaveLocation = DataFiles.ImagesFolder + $"/{imageDownloadData.ImageClassification}{imageDownloadData.ImageId}.jpeg";
                        imageDownloadData.Image.Save(imageSaveLocation, ImageFormat.Jpeg);
                        imageDownloadData.Image.Dispose();
                        imageManifest.Add(new ImageTrainingData()
                        {
                            ImageName = $"{imageDownloadData.ImageClassification}{imageDownloadData.ImageId}",
                            ImageClassification = imageDownloadData.ImageClassification
                        });
                    }

                    imageManifest.AddRange(preExistingImages.Select(o => new ImageTrainingData(){
                        ImageName = $"{o.ImageClassification}{o.ImageId}",
                        ImageClassification = o.ImageClassification
                    }));

                }

                await GenerateImageManifest(imageManifest);

                return true;
            }
            catch (System.Exception e)
            {
                Console.Write(e.ToString());
                return false;
            }
            
        }

        private static IEnumerable<ImageDownloadData> ParseImageDataFile()
        {
            var imageData = File.ReadAllLines(DataFiles.ImageDataSourceTsv)
            .Select(line => line.Split('\t'))
            .Select(tokens => new ImageDownloadData()
            {
                ImageId = tokens[0],
                ImageURL = tokens[1],
                ImageClassification = tokens[2]
            });

            return imageData.Skip(1);
        }

        private async Task<ImageDownloadData> GetImages(ImageDownloadData imageDownloadData)
        {
            if(String.IsNullOrWhiteSpace(imageDownloadData.ImageURL)) return imageDownloadData;

            var imageClientResponse = await _imageDownloadHttpClient.DownloadImage(imageDownloadData.ImageURL);

            if(imageClientResponse.ResponseSuccessful) imageDownloadData.Image = imageClientResponse.Image;
            return imageDownloadData;
        }

        private static async Task GenerateImageManifest(IEnumerable<ImageTrainingData> imageTrainingDatas)
        {
            await File.WriteAllLinesAsync(Path.Combine(DataFiles.ImagesFolder, $"ImageManifest.tsv"), imageTrainingDatas.Select(o => $"{o.ImageName}\t{o.ImageClassification}"));
        }
    }
}