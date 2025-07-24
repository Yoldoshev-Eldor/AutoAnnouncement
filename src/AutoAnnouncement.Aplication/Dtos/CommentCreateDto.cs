namespace AutoAnnouncement.Aplication.Dtos;

public class CommentCreateDto
{
    public string Text { get; set; } = null!;
    public long AnnouncementId { get; set; }
    public long UserId { get; set; }
}
