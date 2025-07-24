using AutoAnnouncement.DataAccess.Repositories.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly MsSqlDbContext _context;

    public PhotoRepository(MsSqlDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddAsync(Photo photo)
    {
        await _context.Photos.AddAsync(photo);
        await _context.SaveChangesAsync();
        return photo.Id;
    }
    public async Task<List<Photo>> GetByAnnouncementIdAsync(long announcementId)
    {
        return await _context.Photos
            .Where(p => p.AnnouncementId == announcementId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Photo photo)
    {
        _context.Photos.Update(photo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var photo = await GetByIdAsync(id);
        if (photo is not null)
        {
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Photo>> GetAllAsync()
    {
        return await _context.Photos.ToListAsync();
    }

    public async Task<Photo> GetByIdAsync(long id)
    {
        return await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
    }
}
