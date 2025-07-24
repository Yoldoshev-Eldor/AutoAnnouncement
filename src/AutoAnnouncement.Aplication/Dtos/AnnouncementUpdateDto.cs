using Microsoft.AspNetCore.Http;

public class AnnouncementUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public IFormFileCollection? NewPhotos { get; set; } // Yangilangan rasm (optional)
}
