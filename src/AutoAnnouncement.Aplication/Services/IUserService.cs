using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Services;

public interface IUserService
{
    Task DeleteUserByIdAsync(long userId, string UserRole);
    Task UpdateUserRoleAsync(long userId, UserRoleGetDto userRoleDto);
}