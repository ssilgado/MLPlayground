using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

using MLPlayground.DataAccess.Implementations;

namespace MLPlayground.DataAccess.Extensions
{
    public static class IocExtensions
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if(env.Equals("Local"))
            {
                services.AddDbContext<MLPlaygroundDbContext>(o => o.UseInMemoryDatabase(databaseName: "mlplayground"));
            } else 
            {
                services.AddDbContext<MLPlaygroundDbContext>(o => o.UseSqlServer());
            }

            return services;
        }
    }
}