using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Services;

public interface ICommentService
{
    Task<long> CreateAsync(CommentCreateDto dto);
    Task UpdateAsync(CommentUpdateDto dto);
    Task DeleteAsync(long id);
    Task<CommentGetDto> GetByIdAsync(long id);
    Task<IEnumerable<CommentGetDto>> GetAllByAnnouncementIdAsync(long announcementId);
}
