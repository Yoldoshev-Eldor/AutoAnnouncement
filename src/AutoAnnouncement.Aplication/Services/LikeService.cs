using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Aplication.Services;

namespace AutoAnnouncement.Application.Services;

public class LikeService(ILikeRepository _repo) : ILikeService
{
    public async Task<bool> HasUserLikedAsync(long userId, long pinId)
    {
        return await _repo.HasUserLikedAsync(userId, pinId);
    }

    public async Task LikeAsync(long userId, long pinId)
    {
        await _repo.LikeAsync(userId, pinId);
    }

    public async Task UnlikeAsync(long userId, long pinId)
    {
        await _repo.UnlikeAsync(userId, pinId);
    }
}
