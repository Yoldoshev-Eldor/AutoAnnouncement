using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.Configurations.Postgres;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Description).IsRequired();

        // Fix for CS1061: Use HasPrecision instead of HasColumnType for decimal properties
        builder.Property(a => a.Price).HasPrecision(18, 2);

        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt).IsRequired();

        // Foreign key: UserId (lekin navigation yo‘q)
        builder.Property(a => a.UserId).IsRequired();

        builder.HasMany(a => a.Photos)
               .WithOne()
               .HasForeignKey("AnnouncementId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
