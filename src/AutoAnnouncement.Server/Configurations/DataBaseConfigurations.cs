using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutoAnnouncement.Server.Configurations;

public static class DatabaseConfigurations
{
    public static void Configuration(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("SqlServer");


        builder.Services.AddDbContext<MsSqlDbContext>(options =>
          options.UseSqlServer(connectionString));

        var connectionStringPS = builder.Configuration.GetConnectionString("PostgreSql");

        builder.Services.AddDbContext<PostgresDbContext>(options =>
            options.UseNpgsql(connectionStringPS
            ));
    }
}