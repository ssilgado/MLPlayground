using System.Threading.Tasks;

using MLPlayground.Models.Models;

namespace MLPlayground.Services.Contracts
{
    public interface IImageDownloadHttpClient
    {
        Task<ImageClientResponse> DownloadImage(string imageURL);
    }
}