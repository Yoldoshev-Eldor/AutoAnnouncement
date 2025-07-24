using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.EntityConfigurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(a => a.Description)
            .HasMaxLength(1000);

        builder.Property(a => a.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(a => a.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(a => a.User)
            .WithMany(u => u.Announcements)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Photos)
            .WithOne(p => p.Announcement)
            .HasForeignKey(p => p.AnnouncementId);

        builder.HasMany(a => a.Likes)
            .WithOne(l => l.Announcement)
            .HasForeignKey(l => l.AnnouncementId);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Announcement)
            .HasForeignKey(c => c.AnnouncementId);
    }
}
