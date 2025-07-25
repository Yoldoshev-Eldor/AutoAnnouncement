﻿using AutoAnnouncement.Aplication.Services;
using Microsoft.AspNetCore.Authorization;

namespace AutoAnnouncement.Server.EndPoints;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this WebApplication app)
    {
        var userGroup = app.MapGroup("/api/role")
            .RequireAuthorization()
            .WithTags("UserRoleManagement");

        userGroup.MapGet("/get-all", [Authorize(Roles = "Admin, SuperAdmin")]
        async (IRoleService _roleService) =>
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Results.Ok(roles);
        })
        .WithName("GetAllRoles");
    }
}