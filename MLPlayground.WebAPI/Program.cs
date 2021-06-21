using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using MLPlayground.DataAccess.Helpers;

namespace MLPlayground.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if(env.Equals("Local")){
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    DataGenerator.Initialize(services);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
