using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Dtos;

public class LikeGetDto
{
    public long Id { get; set; }

    public long AnnouncementId { get; set; }
    public AnnouncementGetDto Announcement { get; set; }

    public long UserId { get; set; }
    public UserGetDto User { get; set; }

    public DateTime LikedAt { get; set; }
}
