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
                var imageDownloadDataList = parseImageDataFile().ToList();
                var imageDownloadDataBatches = imageDownloadDataList.ChunkBy(10);

                foreach(var batch in imageDownloadDataBatches)
                {
                    var downloadImagesTask = batch.Select(o => GetImages(o));

                    var loadedImageDownloadDataList = await Task.WhenAll(downloadImagesTask);

                    var validImageNetDataList = loadedImageDownloadDataList.Where(o => o.Image != null);

                    foreach(var imageDownloadData in validImageNetDataList)
                    {
                        var imageSaveLocation = DataFiles.ImagesFolder + $"/{imageDownloadData.ImageClassification}{imageDownloadData.ImageId}.jpeg";
                        imageDownloadData.Image.Save(imageSaveLocation, ImageFormat.Jpeg);
                    }
                }

                return true;
            }
            catch (System.Exception e)
            {
                Console.Write(e.ToString());
                return false;
            }
            
        }

        private IEnumerable<ImageDownloadData> parseImageDataFile()
        {
            var imageData = File.ReadAllLines(DataFiles.TagsTsv)
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
    }
}