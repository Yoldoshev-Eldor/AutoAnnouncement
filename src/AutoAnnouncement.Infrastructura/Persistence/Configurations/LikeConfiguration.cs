using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.Configurations.Postgres;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Likes");

        builder.HasKey(pl => new { pl.UserId, pl.AnnouncementId });

        builder.Property(pl => pl.LikedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(pl => pl.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pl => pl.Announcement)
            .WithMany(p => p.Likes)
            .HasForeignKey(pl => pl.AnnouncementId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
