//using AutoAnnouncement.Aplication.Dtos;
//using AutoAnnouncement.Aplication.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace AutoAnnouncement.Server.Controllers;

//[Route("api/comment")]
//[ApiController]
//public class CommentController(ICommentService commentService) : ControllerBase
//{
//    [HttpPost("add-comment")]
//    public async Task<long> CreateAsync( CommentCreateDto dto)
//    {
//        return await commentService.CreateAsync(dto);
//    }

//    [HttpPut("update-comment")]
//    public async Task UpdateAsync( CommentUpdateDto dto)
//    {
//        await commentService.UpdateAsync(dto);
//    }

//    [HttpDelete("delete-comment")]
//    public async Task DeleteAsync(long id)
//    {
//        await commentService.DeleteAsync(id);
//    }

//    [HttpGet("getById")]
//    public async Task<CommentGetDto> GetByIdAsync(long id)
//    {
//        return await commentService.GetByIdAsync(id);
//    }

//    [HttpGet("announcement/commentById")]
//    public async Task<IEnumerable<CommentGetDto>> GetAllByAnnouncementIdAsync(long announcementId)
//    {
//        return await commentService.GetAllByAnnouncementIdAsync(announcementId);
//    }
//}
