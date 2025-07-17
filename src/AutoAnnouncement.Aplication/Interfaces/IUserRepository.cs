using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface IUserRepository
{
    Task<long> InsertUserAsync(User user);
    Task<User> SelectUserByIdAsync(long id);
    Task<User> SelectUserByPhoneAsync(string phoneNumber);
    Task UpdateUserRoleAsync(long userId, UserRole userRole);
    Task DeleteUserByIdAsync(long userId);
}
