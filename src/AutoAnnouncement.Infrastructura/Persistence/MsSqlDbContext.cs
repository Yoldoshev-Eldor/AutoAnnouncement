using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructure.Persistence.Configurations.MsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnnouncement.Infrastructura.Persistence;

public class MsSqlDbContext : DbContext
{
    public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());

    }
}