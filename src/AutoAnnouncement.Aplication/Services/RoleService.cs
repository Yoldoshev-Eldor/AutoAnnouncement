﻿using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnnouncement.Aplication.Services;

public class RoleService(IRoleRepository _roleRepo) : IRoleService
{

    public async Task<List<RoleGetDto>> GetAllRolesAsync()
    {
        var roles = await _roleRepo.GetAllRolesAsync();
        return roles.Select(Converter).ToList();
    }

    public async Task<long> GetRoleIdAsync(string role) => await _roleRepo.GetRoleIdAsync(role);

    public async Task<ICollection<UserGetDto>> GetAllUsersByRoleAsync(string role)
    {
        var users = await _roleRepo.GetAllUsersByRoleAsync(role);
        return users.Select(Converter).ToList();
    }

    private RoleGetDto Converter(UserRole role)
    {
        return new RoleGetDto
        {
            Description = role.Description,
            Id = role.Id,
            Name = role.Name,
        };
    }

    private UserGetDto Converter(User user)
    {
        return new UserGetDto
        {
            Email = user.Confirmer.Gmail,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            UserId = user.UserId,
            UserName = user.UserName,
            Role = user.Role.Name,
        };
    }
}
