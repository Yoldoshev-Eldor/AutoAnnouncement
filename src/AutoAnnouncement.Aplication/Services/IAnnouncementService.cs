using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Application.Services.Interfaces;

public interface IAnnouncementService
{
    Task<long> AddAsync(AnnouncementCreateDto dto);
    Task UpdateAsync(AnnouncementUpdateDto dto);
    Task DeleteAsync(long id);
    Task<AnnouncementGetDto> GetByIdAsync(long id);
    Task<IEnumerable<AnnouncementGetDto>> GetAllAsync();
}
