using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAnnouncement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] AnnouncementCreateDto dto)
        {
            var announcementId = await _announcementService.AddAsync(dto);
            return Ok(new { Id = announcementId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] AnnouncementUpdateDto dto)
        {
            await _announcementService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _announcementService.GetAllAsync();
            return Ok(result);
        }
    }
}
