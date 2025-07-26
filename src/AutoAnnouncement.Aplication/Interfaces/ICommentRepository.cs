using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface ICommentRepository
{
    Task<Comment> GetByIdAsync(long id);
    Task<List<Comment>> GetAllByPinIdAsync(long pinId);
    Task AddAsync(Comment comment);
    Task DeleteAsync(Comment comment);
}
