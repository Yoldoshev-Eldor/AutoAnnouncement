using Microsoft.AspNetCore.Http;

public interface IPhotoService
{
    Task<string> AddAsync(IFormFile file);
    Task UpdateAsync(PhotoUpdateDto dto);
    Task DeleteAsync(long id);
    Task<PhotoGetDto> GetByIdAsync(long id);
    Task<List<PhotoGetDto>> GetAllAsync();
    Task<List<PhotoGetDto>> GetByAnnouncementIdAsync(long announcementId);
}
