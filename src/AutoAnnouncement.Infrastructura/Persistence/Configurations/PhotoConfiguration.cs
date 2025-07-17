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
               .HasMaxLength(200);

        // Foreign key - AnnouncementId bo‘ladi, lekin navigation yo‘q
        builder.Property<long>("AnnouncementId");
    }
}
