using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructure.Persistence.Configurations;
using AutoAnnouncement.Infrastructure.Persistence.Configurations.Postgres;
using AutoAnnouncement.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.NetworkInformation;

namespace AutoAnnouncement.Infrastructura.Persistence;

public class MsSqlDbContext : DbContext
{
    

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserConfirme> Confirmers { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Photo> Photos { get; set; }

    public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsSqlDbContext).Assembly);
    }
}