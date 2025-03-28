using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FileManager.Domain.Entities;

namespace FileManager.Infrastructure.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(image => image.Id);
            builder
                .HasIndex(image => image.ImageUrl)
                .IsUnique();
        }
    }
}
