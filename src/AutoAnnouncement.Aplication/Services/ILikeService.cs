namespace AutoAnnouncement.Aplication.Services;

public interface ILikeService
{
    Task<bool> HasUserLikedAsync(long userId, long pinId);
    Task LikeAsync(long userId, long pinId);
    Task UnlikeAsync(long userId, long pinId);
}