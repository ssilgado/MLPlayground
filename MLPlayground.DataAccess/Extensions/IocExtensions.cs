using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using MLPlayground.DataAccess.Implementations;

namespace MLPlayground.DataAccess.Extensions
{
    public static class IocExtensions
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services, string env)
        {
            if(env.Equals("Local"))
            {
                services.AddDbContext<MLPlaygroundDbContext>(o => o.UseSqlite("Filename=:memory:"));
            } else 
            {
                services.AddDbContext<MLPlaygroundDbContext>(o => o.UseSqlServer());
            }

            return services;
        }
    }
}