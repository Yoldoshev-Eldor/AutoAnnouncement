using AutoAnnouncement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoAnnouncement.Infrastructure.Persistence.Configurations.Postgres;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.UserId).IsRequired();
        builder.Property(c => c.AnnouncementId).IsRequired();
        builder.Property(c => c.Text)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasOne<Announcement>()
               .WithMany(a => a.Comments)
               .HasForeignKey(c => c.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
