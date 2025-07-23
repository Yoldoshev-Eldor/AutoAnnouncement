namespace AutoAnnouncement.Domain.Entities;

public class Like
{
    public long Id { get; set; }

    public long AnnouncementId { get; set; }
    public Announcement Announcement { get; set; } = null!;

    public long UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime LikedAt { get; set; } = DateTime.UtcNow;
}
