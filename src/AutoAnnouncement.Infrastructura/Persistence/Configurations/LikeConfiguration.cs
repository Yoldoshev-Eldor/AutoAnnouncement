using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.Configurations.Postgres;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Likes");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
               .ValueGeneratedOnAdd();

        builder.Property(l => l.UserId)
               .IsRequired();

        builder.Property(l => l.AnnouncementId)
               .IsRequired();

        builder.Property(l => l.LikedAt)
               .IsRequired();

        builder.HasOne(l => l.Announcement)
               .WithMany(a => a.Likes)
               .HasForeignKey(l => l.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.User)
               .WithMany(u => u.Likes) // Agar `User`da `ICollection<Like> Likes` bo‘lsa
               .HasForeignKey(l => l.UserId)
               .OnDelete(DeleteBehavior.NoAction); // yoki .Restrict() — sizga qanday kerakligiga qarab
    }
}
