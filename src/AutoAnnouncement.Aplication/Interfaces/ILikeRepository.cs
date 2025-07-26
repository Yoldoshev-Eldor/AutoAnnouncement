using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface ILikeRepository
{
    Task<bool> HasUserLikedAsync(long userId, long pinId);
    Task LikeAsync(long userId, long pinId);
    Task UnlikeAsync(long userId, long pinId);
}
