using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllAsync(); 
    Task<Comment?> GetByIdAsync(long id);     
    Task<IEnumerable<Comment>> GetByAnnouncementIdAsync(long announcementId); 
    Task<long> AddAsync(Comment comment);     
    Task UpdateAsync(Comment comment);        
    Task DeleteAsync(long id);                
}
