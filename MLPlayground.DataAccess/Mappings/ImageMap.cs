using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MLPlayground.DataAccess.Entities;

namespace MLPlayground.DataAccess.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            
            builder.HasKey(e => e.ImageKey)
                .HasName("pkImageOnImageKey");

            builder.Property(e => e.ImageData)
                .IsFixedLength();

            builder.Property(e => e.RowCreateTs)
                .HasColumnType("datetime");

            builder.Property(e => e.RowMaintenanceTs)
                .HasColumnType("datetime");
        }
    }
}