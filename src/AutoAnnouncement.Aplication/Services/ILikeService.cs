using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Service.DTOs.Likes;

namespace AutoAnnouncement.Aplication.Services;

public interface ILikeService
{
    Task<long> AddAsync(LikeCreateDto like);
    Task DeleteAsync(long id);
    Task<IEnumerable<LikeGetDto>> GetAllAsync();
    Task<IEnumerable<LikeGetDto>> GetByAnnouncementIdAsync(long announcementId);
    Task<LikeGetDto> GetByIdAsync(long id);
    Task UpdateAsync(LikeUpdateDto like);
}