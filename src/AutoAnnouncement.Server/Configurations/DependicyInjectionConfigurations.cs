using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Helpers;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Aplication.Services;
using AutoAnnouncement.Aplication.Validators;
using AutoAnnouncement.Application.Services;
using AutoAnnouncement.Application.Services.Interfaces;
using AutoAnnouncement.DataAccess.Repositories.Interfaces;
using AutoAnnouncement.Infrastructura.Repositories;
using FluentValidation;

namespace AutoAnnouncement.Server.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
        builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        builder.Services.AddScoped<IPhotoService, PhotoService>();
        builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IRoleRepository, UserRoleRepository>();
        

        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddScoped<ILikeRepository, LikeRepository>();
        builder.Services.AddScoped<ILikeService, LikeService>();
        builder.Services.AddScoped<ICommentService, CommentService>();

        builder.Services.AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();





    }
}