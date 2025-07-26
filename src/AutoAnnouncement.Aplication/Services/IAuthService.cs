using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Services;

public interface IAuthService
{
    Task<long> SignUpUserAsync(UserCreateDto userCreateDto);
    Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request);
    Task LogOut(string token);
    Task EailCodeSender(string email);
    Task<bool> ConfirmCode(string userCode, string email);
}