using User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User.Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<User.Domain.Entities.User> builder)
        {
            builder.HasKey(user => user.userId);
            builder
                .HasIndex(user => user.email)
                .IsUnique();
        }
    }
}