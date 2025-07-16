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

public class RefreshTokenRepository : IRefreshTokenRepository
{

    private readonly MsSqlDbContext MsSqlDbContext;

    public RefreshTokenRepository(MsSqlDbContext mainDbContext)
    {
        MsSqlDbContext = mainDbContext;
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await MsSqlDbContext.RefreshTokens.AddAsync(refreshToken);
        await MsSqlDbContext.SaveChangesAsync();
    }

    public async Task RemoveRefreshTokenAsync(string token)
    {
        var rToken = await MsSqlDbContext.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

        if (rToken == null)
        {
            throw new Exception($"Refresh token {token} not found");
        }

        MsSqlDbContext.RefreshTokens.Remove(rToken);
        await MsSqlDbContext.SaveChangesAsync();
    }

    public async Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId)
    {
        return await MsSqlDbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.UserId == userId);
    }
}