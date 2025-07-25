﻿using System.Net.NetworkInformation;

namespace AutoAnnouncement.Domain.Entities;

public class Comment
{
    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long AnnouncementId { get; set; }
    public Announcement Announcement { get; set; }
}
