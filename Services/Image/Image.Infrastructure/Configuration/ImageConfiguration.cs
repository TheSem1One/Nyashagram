using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Image.Infrastructure.Configuration
{
    class ImageConfiguration : IEntityTypeConfiguration<Domain.Entities.Image>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Image> builder)
        {
            builder.HasKey(image => image.Id);
            builder
                .HasIndex(image => image.ImageId)
                .IsUnique();
        }
    }
}
