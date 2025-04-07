using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = FileManager.Domain.Entities.File;

namespace FileManager.Infrastructure.Configuration
{
    class FileManagerConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(image => image.Id);
            builder
                .HasIndex(image => image.FileUrl)
                .IsUnique();
        }
    }


}
