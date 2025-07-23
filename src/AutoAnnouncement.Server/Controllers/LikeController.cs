using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Services;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Service.DTOs.Likes;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AutoAnnouncement.Server.Controllers;

[Route("api/like")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }

    [HttpPost("add-like")]
    public async Task<long> AddAsync(LikeCreateDto like)
    {
        var id = await _likeService.AddAsync(like);
        return id;
    }

    [HttpGet("get-all-like")]
    public async Task<IEnumerable<LikeGetDto>> GetAllAsync()
    {
        return await _likeService.GetAllAsync();
        
    }

    [HttpGet("get-like-by-id")]
    public async Task<LikeGetDto> GetByIdAsync(long id)
    {
        return await _likeService.GetByIdAsync(id);
    
    }

    [HttpDelete("delete-like")]
    public async Task DeleteAsync(long id)
    {
        await _likeService.DeleteAsync(id);
        
    }

    [HttpPut("update-like")]
    public async Task UpdateAsync( LikeUpdateDto like)
    {
        await _likeService.UpdateAsync(like);
        
    }

    [HttpGet("get-like-anouncementbyid")]
    public async Task<IActionResult> GetByAnnouncementIdAsync(long announcementId)
    {
        var result = await _likeService.GetByAnnouncementIdAsync(announcementId);
        return Ok(result);
    }
}
