using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Services;

public interface IUserService
{
    Task UpdateUserRoleAsync(long userId, string userRole);
    Task DeleteUserByIdAsync(long userId, string userRole);
}
