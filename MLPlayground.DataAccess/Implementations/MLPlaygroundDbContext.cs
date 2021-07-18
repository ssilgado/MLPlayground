using Microsoft.EntityFrameworkCore;

using MLPlayground.DataAccess.Entities;

#nullable disable

namespace MLPlayground.DataAccess.Implementations
{
    public partial class MLPlaygroundDbContext : DbContext
    {
        public MLPlaygroundDbContext()
        {
        }

        public MLPlaygroundDbContext(DbContextOptions<MLPlaygroundDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProcessStatus> ProcessStatuses { get; set; }
        public virtual DbSet<RefStatus> RefStatuses { get; set; }
        public virtual DbSet<ImageRecord> ImageRecords { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MLPlaygroundDbContext).Assembly);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
