using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Services;

public class UserService : IUserService
{
    private readonly IUserRepository UserRepository;


    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task DeleteUserByIdAsync(long userId, string userRole)
    {
        if (userRole == "SuperAdmin")
        {
            await UserRepository.DeleteUserByIdAsync(userId);
        }
        else if (userRole == "Admin")
        {
            var user = await UserRepository.SelectUserByIdAsync(userId);
            if (user.Role == UserRole.User)
            {
                await UserRepository.DeleteUserByIdAsync(userId);
            }
            else
            {
                throw new Exception("Admin can not delete Admin or SuperAdmin");
            }
        }
    }

    public async Task UpdateUserRoleAsync(long userId, UserRoleGetDto userRoleDto)
    {
        await UserRepository.UpdateUserRoleAsync(userId, (UserRole)userRoleDto);
    }
}
