
using AutoAnnouncement.Server.Configurations;
using AutoAnnouncement.Server.EndPoints;

namespace AutoAnnouncement.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.ConfigureSerilog();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Configure();
            builder.ConfigureJwtSettings();
            builder.Configuration();
            builder.ConfigurationJwtAuth();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseCors("AllowAll");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/hello", () => "Hello, World!")
            .WithName("HelloEndpoint")
            .WithTags("Custom Section");

            app.MapAuthEndpoints();
            app.MapRoleEndpoints();
            app.MapAdminEndpoints();
            app.MapCommentEndpoints();
            app.MapLikeEndpoints();

            app.MapControllers();

            app.Run();
        }
    }
}
