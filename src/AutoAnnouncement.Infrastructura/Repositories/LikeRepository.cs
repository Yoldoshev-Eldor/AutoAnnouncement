using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly PostgresDbContext _context;

    public LikeRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddAsync(Like like)
    {
        _context.Likes.Add(like);
        await _context.SaveChangesAsync();
        return like.Id; 
    }

    public async Task DeleteAsync(long id)
    {
        var like = await _context.Likes.FindAsync(id);
        if (like is not null)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Like>> GetAllAsync()
    {
        return await _context.Likes.ToListAsync();
    }

    public async Task<IEnumerable<Like>> GetByAnnouncementIdAsync(long announcementId)
    {
        return await _context.Likes
            .Where(l => l.AnnouncementId == announcementId)
            .ToListAsync();
    }

    public async Task<Like> GetByIdAsync(long id)
    {
        return await _context.Likes.FindAsync(id);
    }

    public async Task UpdateAsync(Like like)
    {
        _context.Likes.Update(like);
        await _context.SaveChangesAsync();
    }
}
