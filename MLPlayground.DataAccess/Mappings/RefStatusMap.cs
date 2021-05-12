using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MLPlayground.DataAccess.Entities;

namespace MLPlayground.DataAccess.Mappings
{
    public class RefStatusMap : IEntityTypeConfiguration<RefStatus>
    {
        public void Configure(EntityTypeBuilder<RefStatus> builder)
        {
            builder.ToTable("refStatus");

            builder.HasKey(e => e.StatusKey)
                .HasName("pkRefStatusOnStatusKey");

            builder.Property(e => e.RowCreateTs).HasColumnType("datetime");

            builder.Property(e => e.RowMaintenanceTs).HasColumnType("datetime");

            builder.Property(e => e.StatusName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}