using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.Configurations.MsSql;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Salt).IsRequired();
        builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(u => u.Role).IsRequired();

        // 1 user → ko‘p refresh token
        builder.HasMany(u => u.RefreshTokens)
               .WithOne()
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade);

        // Announcement navigatsiya mavjud bo‘lsa ham, boshqa DBda bo‘lgani uchun ignore qilamiz
        builder.Ignore(u => u.Announcements);
    }
}
