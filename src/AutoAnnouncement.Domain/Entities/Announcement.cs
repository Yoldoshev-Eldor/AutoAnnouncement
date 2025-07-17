namespace AutoAnnouncement.Domain.Entities;

public class Announcement
{
    public long Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long UserId { get; set; }
}


