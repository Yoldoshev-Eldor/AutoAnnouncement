﻿using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Dtos;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}