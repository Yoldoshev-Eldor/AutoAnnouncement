//using AutoAnnouncement.Aplication.Dtos;
//using AutoAnnouncement.Aplication.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace AutoAnnouncement.Server.Controllers;

//[Route("api/auth")]
//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly IAuthService AuthService;
//    public AuthController(IAuthService authService)
//    {
//        AuthService = authService;
//    }

//    [HttpPost("signUp")]
//    public async Task<long> SignUp(UserCreateDto userCreateDto)
//    {
//        return await AuthService.SignUpUserAsync(userCreateDto);
//    }

//    [HttpPost("login")]
//    public async Task<LoginResponseDto> Login(UserLoginDto userLoginDto)
//    {
//        return await AuthService.LoginUserAsync(userLoginDto);
//    }

//    [HttpPost("refreshToken")]
//    public async Task<LoginResponseDto> RefreshToken(RefreshRequestDto request)
//    {
//        return await AuthService.RefreshTokenAsync(request);
//    }

//    [HttpDelete("logOut")]
//    public async Task LogOut(string token)
//    {
//        await AuthService.LogOutAsync(token);
//    }
//}