using Microsoft.AspNetCore.Http;

public class PhotoCreateDto
{
    public IFormFile Image { get; set; }
    public long AnnouncementId { get; set; }
}
