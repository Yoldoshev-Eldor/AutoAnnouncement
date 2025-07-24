using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.DataAccess.Repositories.Interfaces;

public interface IPhotoRepository
{
    Task<long> AddAsync(Photo photo);
    Task UpdateAsync(Photo photo);
    Task DeleteAsync(long id);
    Task<IEnumerable<Photo>> GetAllAsync();
    Task<Photo> GetByIdAsync(long id);
    Task<List<Photo>> GetByAnnouncementIdAsync(long announcementId);
}
