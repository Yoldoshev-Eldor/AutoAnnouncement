using AutoAnnouncement.Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnnouncement.Aplication.Helpers;

public interface ITokenService
{
    public string GenerateToken(UserGetDto user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}