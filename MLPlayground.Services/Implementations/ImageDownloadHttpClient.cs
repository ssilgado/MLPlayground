using System.Net.Http;

using MLPlayground.Services.Contracts;
using MLPlayground.Models.Models;

namespace MLPlayground.Services.Implementations
{
    public class ImageDownloadHttpClient: IImageDownloadHttpClient
    {
        private readonly HttpClient _httpClient;

        public ImageDownloadHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public ImageClientResponse DownloadImage(string imageURL){
            return new ImageClientResponse();
        }
    }
}