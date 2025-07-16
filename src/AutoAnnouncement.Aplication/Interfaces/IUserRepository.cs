using AutoAnnouncement.Domain.Entities;

namespace AutoAnnouncement.Aplication.Interfaces;

public interface IUserRepository
{
    Task<int> InsertUserAsync(User user);
    Task<User> SelectUserByIdAsync(int id);
    Task<User> SelectUserPhoneAsync(string phoneNumber);
    Task UpdateUserAsync(User user);
    Task DeleteUserByIdAsync(int userId);
    Task ResetPasswordAsync(int userId, string password);
}
