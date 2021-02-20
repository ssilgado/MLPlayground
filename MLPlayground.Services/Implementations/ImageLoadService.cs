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
                var imageNetDataList = parseImageDataFile().ToList();
                var imageNetDataBatches = imageNetDataList.ChunkBy(10);

                foreach(var batch in imageNetDataBatches)
                {
                    var downloadImagesTask = batch.Select(o => GetImages(o));

                    var loadedImageNetDataList = await Task.WhenAll(downloadImagesTask);

                    var validImageNetDataList = loadedImageNetDataList.Where(o => o.Image != null);

                    foreach(var imageNetData in validImageNetDataList)
                    {
                        var imageSaveLocation = DataFiles.ImagesFolder + $"/{imageNetData.ImageClassification}{imageNetData.ImageId}.jpeg";
                        imageNetData.Image.Save(imageSaveLocation, ImageFormat.Jpeg);
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

        private IEnumerable<ImageNetData> parseImageDataFile()
        {
            var imageData = File.ReadAllLines(DataFiles.TagsTsv)
            .Select(line => line.Split('\t'))
            .Select(tokens => new ImageNetData()
            {
                ImageId = tokens[0],
                ImageURL = tokens[1],
                ImageClassification = tokens[2]
            });

            return imageData.Skip(1);
        }

        private async Task<ImageNetData> GetImages(ImageNetData imageNetData)
        {
            if(String.IsNullOrWhiteSpace(imageNetData.ImageURL)) return imageNetData;

            var imageClientResponse = await _imageDownloadHttpClient.DownloadImage(imageNetData.ImageURL);

            if(imageClientResponse.ResponseSuccessful) imageNetData.Image = imageClientResponse.Image;
            return imageNetData;
        }
    }
}