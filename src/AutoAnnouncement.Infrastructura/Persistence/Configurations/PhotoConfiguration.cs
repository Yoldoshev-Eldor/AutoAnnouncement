using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.Configurations.Postgres;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Url)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(p => p.AnnouncementId)
               .IsRequired();

        builder.HasOne(p => p.Announcement)
               .WithMany(a => a.Photos)
               .HasForeignKey(p => p.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
