using AutoAnnouncement.Aplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoAnnouncement.Server.EndPoints;

public static class AdminEndpoints
{
    public static void MapAdminEndpoints(this WebApplication app)
    {
        var adminGroup = app.MapGroup("/api/admin")
                             .WithTags("AdminManagement");

        // Get all users by role
        adminGroup.MapGet("/get-all-users-by-role",
            [Authorize(Roles = "Admin,SuperAdmin")]
        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Any, NoStore = false)]
        async ([FromQuery] string role, [FromServices] IRoleService roleService) =>
            {
                var users = await roleService.GetAllUsersByRoleAsync(role);
                return Results.Ok(new { success = true, data = users });
            })
        .WithName("GetAllUsersByRole");

        // Delete user by ID
        adminGroup.MapDelete("/delete-user-by-id",
            [Authorize(Roles = "Admin,SuperAdmin")]
        async ([FromQuery] long userId, HttpContext httpContext, [FromServices] IUserService userService) =>
            {
                var role = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                if (string.IsNullOrWhiteSpace(role))
                    return Results.BadRequest("User role not found.");

                await userService.DeleteUserByIdAsync(userId, role);
                return Results.Ok(new { success = true });
            })
        .WithName("DeleteUser");

        // Update user role
        adminGroup.MapPatch("/update-role",
            [Authorize(Roles = "SuperAdmin")]
        async ([FromQuery] long userId, [FromQuery] string userRole, [FromServices] IUserService userService) =>
            {
                await userService.UpdateUserRoleAsync(userId, userRole);
                return Results.Ok(new { success = true });
            })
        .WithName("UpdateUserRole");
    }
}
