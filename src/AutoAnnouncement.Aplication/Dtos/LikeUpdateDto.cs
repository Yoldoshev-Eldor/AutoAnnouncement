namespace AutoAnnouncement.Service.DTOs.Likes;

public class LikeUpdateDto
{
    public long Id { get; set; }
    public long AnnouncementId { get; set; }
    public long UserId { get; set; }
}
