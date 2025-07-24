using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Dtos;

public class CommentGetDto
{
    public long Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public long AnnouncementId { get; set; }
    public AnnouncementGetDto Announcement { get; set; } = null!;

    public long UserId { get; set; }
    public UserGetDto User { get; set; } = null!;
}
