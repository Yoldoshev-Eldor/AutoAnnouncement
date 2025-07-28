using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoAnnouncement.Server.Controllers
{
    [Route("api/announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost("add-announcement")]
        [Authorize] // Token kerak bo'lishi uchun
        public async Task<IActionResult> AddAsync([FromForm] AnnouncementCreateDto dto)
        {
            // JWT token ichidan UserId ni olish
            var userIdClaim = HttpContext.User.FindFirst("UserId");
            if (userIdClaim == null)
                return Unauthorized(new { message = "UserId not found in token" });

            if (!long.TryParse(userIdClaim.Value, out long userId))
                return BadRequest(new { message = "Invalid UserId in token" });

            // Servicega userId ni uzatish
            var announcementId = await _announcementService.AddAsync(dto, userId);
            return Ok(new { Id = announcementId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] AnnouncementUpdateDto dto)
        {
            await _announcementService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("delete-announcement")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _announcementService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _announcementService.GetByIdAsync(id);
            if (result == null)
                return NotFound("E'lon topilmadi");

            return Ok(result);
        }

        [HttpGet("get-all-announcement")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _announcementService.GetAllAsync();
            return Ok(result);
        }
    }
}
