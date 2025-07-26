namespace AutoAnnouncement.Aplication;

public class CommentDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserName { get; set; }
    public long AnnouncementId { get; set; }
}