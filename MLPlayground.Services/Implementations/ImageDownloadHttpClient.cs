using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.IO;

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
        public async Task<ImageClientResponse> DownloadImage(string imageURL){
            try
            {
                var responseByteStream = await _httpClient.GetByteArrayAsync(imageURL);
                var responseImage = Image.FromStream(new MemoryStream(responseByteStream));

                return new ImageClientResponse()
                {
                    Image = responseImage
                };
            }
            catch(System.Exception e)
            {
                return new ImageClientResponse()
                {
                    Errors = new string[] {e.ToString()}
                };
            }
        }
    }
}