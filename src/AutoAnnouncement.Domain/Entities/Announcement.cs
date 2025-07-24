using System.Xml.Linq;

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
    public User User { get; set; }
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}


