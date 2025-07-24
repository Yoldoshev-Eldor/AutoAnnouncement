using Microsoft.AspNetCore.Http;

public class AnnouncementCreateDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }

    public IFormFileCollection Photos { get; set; }  // Rasm yuboriladi
}
