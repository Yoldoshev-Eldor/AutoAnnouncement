﻿namespace AutoAnnouncement.Domain.Entities;

public class Photo
{
    public long Id { get; set; }
    public string Url { get; set; }
    public long AnnouncementId { get; set; }
    public Announcement Announcement { get; set; }
}
