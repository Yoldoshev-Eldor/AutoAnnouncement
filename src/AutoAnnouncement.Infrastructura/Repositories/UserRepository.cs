using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MsSqlDbContext MsSqlDbContext;

    public UserRepository(MsSqlDbContext mainDbContext)
    {
        MsSqlDbContext = mainDbContext;
    }

    public async Task<User> SelectUserByPhoneAsync(string phoneNumber)
    {
        var user = await MsSqlDbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        if (user == null)
        {
            throw new Exception($"Entity with userName : {user} not found");
        }

        return user;
    }

    public async Task<long> InsertUserAsync(User user)
    {
        await MsSqlDbContext.Users.AddAsync(user);
        await MsSqlDbContext.SaveChangesAsync();
        return user.UserId;
    }

    public async Task<User> SelectUserByIdAsync(long id)
    {
        var user = await MsSqlDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user == null)
        {
            throw new Exception($"Entity with {id} not found");
        }

        return user;
    }

    public async Task UpdateUserRoleAsync(long userId, UserRole userRole)
    {
        var user = await SelectUserByIdAsync(userId);
        user.Role = userRole;
        MsSqlDbContext.Users.Update(user);
        await MsSqlDbContext.SaveChangesAsync();
    }

    public async Task DeleteUserByIdAsync(long userId)
    {
        var user = await SelectUserByIdAsync(userId);
        MsSqlDbContext.Users.Remove(user);
        await MsSqlDbContext.SaveChangesAsync();
    }
}
