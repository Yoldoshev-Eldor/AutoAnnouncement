using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface ILikeRepository
{
    Task<IEnumerable<Like>> GetAllAsync();
    Task<Like?> GetByIdAsync(long id);
    Task<IEnumerable<Like>> GetByAnnouncementIdAsync(long announcementId);
    Task<long> AddAsync(Like like);
    Task UpdateAsync(Like like);
    Task DeleteAsync(long id);
}
