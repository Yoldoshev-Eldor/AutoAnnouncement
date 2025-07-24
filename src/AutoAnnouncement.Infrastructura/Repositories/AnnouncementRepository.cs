using AutoAnnouncement.DataAccess.Repositories.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly MsSqlDbContext _context;

    public AnnouncementRepository(MsSqlDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddAsync(Announcement announcement)
    {
        await _context.Announcements.AddAsync(announcement);
        await _context.SaveChangesAsync();
        return announcement.Id;
    }

    public async Task UpdateAsync(Announcement announcement)
    {
        _context.Announcements.Update(announcement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var announcement = await _context.Announcements.FindAsync(id);
        if (announcement is not null)
        {
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Announcement>> GetAllAsync()
    {
        return await _context.Announcements
            .Include(a => a.Photos)
            .Include(a => a.Likes)
            .Include(a => a.Comments)
            .ToListAsync();
    }

    public async Task<Announcement?> GetByIdAsync(long id)
    {
        return await _context.Announcements
            .Include(a => a.Photos)
            .Include(a => a.Likes)
            .Include(a => a.Comments)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
