namespace AutoAnnouncement.Domain.Entities;

public class Like
{
    public long Id { get; set; }

    public long AnnouncementId { get; set; }
    public Announcement Announcement { get; set; } 

    public long UserId { get; set; }
    public User User { get; set; } 

    public DateTime LikedAt { get; set; } = DateTime.UtcNow;
}
