using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly PostgresDbContext _context;

    public CommentRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment.Id;
    }

    public async Task DeleteAsync(long id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Comment>> GetAllAsync()
    {
        return await _context.Comments
            .Include(c => c.Announcement) // Agar kerak bo‘lsa
            .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetByAnnouncementIdAsync(long announcementId)
    {
        return await _context.Comments
            .Where(c => c.AnnouncementId == announcementId)
            .ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(long id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task UpdateAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }
}
