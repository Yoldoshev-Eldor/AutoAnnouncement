using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllAsync(); // Hammasini olish
    Task<Comment?> GetByIdAsync(long id);     // ID bo‘yicha olish
    Task<IEnumerable<Comment>> GetByAnnouncementIdAsync(long announcementId); // Faqat bitta elonga tegishlilar
    Task<long> AddAsync(Comment comment);     // Qo‘shish va Id qaytarish
    Task UpdateAsync(Comment comment);        // Yangilash
    Task DeleteAsync(long id);                // O‘chirish
}
