using AutoAnnouncement.Aplication.Helpers;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Aplication.Services;
using AutoAnnouncement.Infrastructura.Repositories;

namespace AutoAnnouncement.Server.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        //builder.Services.AddScoped<IToDoItemRepository, AdoNetWithSpAndFn>();
        builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        

        builder.Services.AddScoped<ITokenService, TokenService>();

        //builder.Services.AddScoped<ToDoItemUpdateDtoValidator, ToDoItemUpdateDtoValidator>();
        //builder.Services.AddScoped<ToDoItemCreateDtoValidator, ToDoItemCreateDtoValidator>();

        //builder.Services.AddScoped<IValidator<ToDoItemCreateDto>, ToDoItemCreateDtoValidator>();
        //builder.Services.AddScoped<IValidator<ToDoItemUpdateDto>, ToDoItemUpdateDtoValidator>();




    }
}