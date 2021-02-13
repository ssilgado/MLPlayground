using MLPlayground.Models.Models;

namespace MLPlayground.Services.Contracts
{
    public interface IImageDownloadHttpClient
    {
        ImageClientResponse DownloadImage(string imageURL);
    }
}