using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Services;

public interface ICommentService
{
    Task<CommentDto> GetByIdAsync(long id);
    Task<List<CommentDto>> GetAllByPinIdAsync(long pinId);
    Task AddAsync(CommentCreateDto comment, long userId);
    Task DeleteAsync(long commentId, long userId);
}
