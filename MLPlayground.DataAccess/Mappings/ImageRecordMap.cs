using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MLPlayground.DataAccess.Entities;

namespace MLPlayground.DataAccess.Mappings
{
    public class ImageRecordMap : IEntityTypeConfiguration<ImageRecord>
    {
        public void Configure(EntityTypeBuilder<ImageRecord> builder)
        {
            builder.ToTable("ImageRecord");
            
            builder.HasKey(e => e.ImageRecordKey)
                .HasName("pkImageRecordOnImageRecordKey");

            builder.Property(e => e.ImageKey)
                .HasColumnName("ImageKey");

            builder.Property(e => e.ImageCategory)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.RowCreateTs)
                .HasColumnType("datetime");

            builder.Property(e => e.RowMaintenanceTs)
                .HasColumnType("datetime");

            builder.HasOne(e => e.Image)
                .WithOne(e => e.ImageRecord)
                .HasForeignKey<Image>(e => e.ImageKey);
        }
    }
}