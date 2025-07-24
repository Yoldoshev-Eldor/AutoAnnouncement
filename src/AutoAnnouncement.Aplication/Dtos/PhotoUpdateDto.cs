using Microsoft.AspNetCore.Http;

public class PhotoUpdateDto
{
    public long Id { get; set; }
    public IFormFile NewImage { get; set; }
}
