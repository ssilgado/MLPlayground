using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

using MLPlayground.Services.Contracts;
using MLPlayground.Services.Implementations;

namespace MLPlayground.Services.Extensions
{
    public static class IocExtensions
    {
        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services)
        {
            services.AddScoped<IImageDownloadHttpClient, ImageDownloadHttpClient>();
            services.AddScoped<IImageLoadService, ImageLoadService>();

            services.AddHttpClient<IImageDownloadHttpClient,ImageDownloadHttpClient>();
            return services;
        }
    }
}