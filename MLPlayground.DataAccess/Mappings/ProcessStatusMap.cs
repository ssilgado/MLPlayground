using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MLPlayground.DataAccess.Entities;

namespace MLPlayground.DataAccess.Mappings
{
    public class ProcessStatusMap : IEntityTypeConfiguration<ProcessStatus>
    {
        public void Configure(EntityTypeBuilder<ProcessStatus> builder)
        {
            builder.ToTable("ProcessStatus");
            
            builder.HasKey(e => e.ProcessStatusKey)
                .HasName("pkProcessStatusOnProcessStatusKey");

            builder.Property(e => e.ProcessGuid)
                .HasColumnName("ProcessGUID");

            builder.Property(e => e.RowCreateTs)
                .HasColumnType("datetime");

            builder.Property(e => e.RowMaintenanceTs)
                .HasColumnType("datetime");

            builder.HasOne(d => d.StatusKeyNavigation)
                .WithMany(p => p.ProcessStatuses)
                .HasForeignKey(d => d.StatusKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkProcessStatusOnStatusStatusKey");
        }
    }
}