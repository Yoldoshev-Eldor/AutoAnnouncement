using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class LikeRepository(MsSqlDbContext _context) : ILikeRepository
{
    public async Task<bool> HasUserLikedAsync(long userId, long pinId)
    {
        return await _context.Likes
            .AnyAsync(pl => pl.UserId == userId && pl.AnnouncementId == pinId);
    }

    public async Task LikeAsync(long userId, long pinId)
    {
        bool alreadyLiked = await HasUserLikedAsync(userId, pinId);
        if (!alreadyLiked)
        {
            var pinLike = new Like
            {
                UserId = userId,
                AnnouncementId = pinId,
                LikedAt = DateTime.UtcNow
            };

            _context.Likes.Add(pinLike);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UnlikeAsync(long userId, long pinId)
    {
        var pinLike = await _context.Likes
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.AnnouncementId == pinId);

        if (pinLike != null)
        {
            _context.Likes.Remove(pinLike);
            await _context.SaveChangesAsync();
        }
    }
}
