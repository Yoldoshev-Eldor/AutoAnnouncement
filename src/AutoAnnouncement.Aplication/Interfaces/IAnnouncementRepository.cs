using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.DataAccess.Repositories.Interfaces;

public interface IAnnouncementRepository
{
    Task<long> AddAsync(Announcement announcement);
    Task UpdateAsync(Announcement announcement);
    Task DeleteAsync(long id);
    Task<IEnumerable<Announcement>> GetAllAsync();
    Task<Announcement> GetByIdAsync(long id);
}
