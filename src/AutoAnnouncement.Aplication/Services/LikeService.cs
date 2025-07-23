using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Aplication.Services;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Service.DTOs.Likes;

namespace AutoAnnouncement.Application.Services;

public class LikeService : ILikeService
{
    private readonly ILikeRepository _likeRepository;

    public LikeService(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<long> AddAsync(LikeCreateDto like)
    {
        var likeEntity = new Like
        {
            AnnouncementId = like.AnnouncementId,
            UserId = like.UserId,
            LikedAt = DateTime.UtcNow
        };
        return await _likeRepository.AddAsync(likeEntity);
    }

    public async Task DeleteAsync(long id)
    {
        await _likeRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LikeGetDto>> GetAllAsync()
    {
        var likes = await _likeRepository.GetAllAsync();
        return likes.Select(ConvertToDto);
    }

    public async Task<IEnumerable<LikeGetDto>> GetByAnnouncementIdAsync(long announcementId)
    {
        var likes = await _likeRepository.GetByAnnouncementIdAsync(announcementId);

        return likes.Select(ConvertToDto);

    }

    public async Task<LikeGetDto> GetByIdAsync(long id)
    {
        var like = await _likeRepository.GetByIdAsync(id);
        return ConvertToDto(like);
    }

    public async Task UpdateAsync(LikeUpdateDto likeUpdatedto)
    {
        var like = new Like
        {
            Id = likeUpdatedto.Id,
            AnnouncementId = likeUpdatedto.AnnouncementId,
            UserId = likeUpdatedto.UserId,
        };

        await _likeRepository.UpdateAsync(like);
    }

    private Like ConvertToEntity(LikeGetDto likeDto)
    {
        return new Like
        {
            Id = likeDto.Id,
            AnnouncementId = likeDto.AnnouncementId,
            UserId = likeDto.UserId,
            LikedAt = likeDto.LikedAt
        };
    }
    private LikeGetDto ConvertToDto(Like like)
    {
        return new LikeGetDto
        {
            Id = like.Id,
            AnnouncementId = like.AnnouncementId,
            UserId = like.UserId,
            LikedAt = like.LikedAt
        };
    }
}
