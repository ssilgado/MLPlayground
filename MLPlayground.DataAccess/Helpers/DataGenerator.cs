using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MLPlayground.DataAccess.Entities;
using MLPlayground.DataAccess.Implementations;


namespace MLPlayground.DataAccess.Helpers
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MLPlaygroundDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MLPlaygroundDbContext>>()))
            {
                // Do Not Need To Seed The Data If It Already Exists
                if (context.RefStatuses.Any())
                {
                    return;
                }

                var defaultStatuses = new List<RefStatus>
                {
                    new RefStatus {StatusName = "In Progress", RowCreateTs = DateTime.Now, RowMaintenanceTs = DateTime.Now},
                    new RefStatus {StatusName = "Completed", RowCreateTs = DateTime.Now, RowMaintenanceTs = DateTime.Now},
                    new RefStatus {StatusName = "Cancelled", RowCreateTs = DateTime.Now, RowMaintenanceTs = DateTime.Now},
                };

                context.AddRangeAsync(defaultStatuses);
                context.SaveChanges();
            }
        }
    }
}
