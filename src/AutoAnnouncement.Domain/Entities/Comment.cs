namespace AutoAnnouncement.Domain.Entities;

public class Comment
{
    public long Id { get; set; }

    public string Text { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public long AnnouncementId { get; set; }
    public Announcement Announcement { get; set; } = null!;

    public long UserId { get; set; }
    public User User { get; set; } = null!;
}
