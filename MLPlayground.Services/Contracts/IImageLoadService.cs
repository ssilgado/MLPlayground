using System.Threading.Tasks;

namespace MLPlayground.Services.Contracts
{
    public interface IImageLoadService
    {
        Task<bool> LoadImages();
    }
}