using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

using MLPlayground.Services.Contracts;
using MLPlayground.Services.Implementations;
using MLPlayground.DataAccess.Extensions;

namespace MLPlayground.Services.Extensions
{
    public static class IocExtensions
    {
        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services, string env)
        {
            services.AddScoped<IImageDownloadHttpClient, ImageDownloadHttpClient>();
            services.AddScoped<IImageLoadService, ImageLoadService>();

            services.AddHttpClient<IImageDownloadHttpClient,ImageDownloadHttpClient>();

            services.RegisterDataAccess(env);
            
            return services;
        }
    }
}