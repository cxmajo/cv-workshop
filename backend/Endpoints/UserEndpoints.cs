using backend.Data.Mappers;
using backend.Data.Requests;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        // GET /users
        app.MapGet(
                "/users",
                async (ICvService cvService) =>
                {
                    var users = await cvService.GetAllUsersAsync();
                    var userDtos = users.Select(u => UserMapper.ToDto(u)).ToList();

                    return Results.Ok(userDtos);
                }
            )
            .WithName("GetAllUsers")
            .WithTags("Users");


        // GET /users/{id}
        app.MapGet(
            "/users/{id:guid}",
            async (Guid id, ICvService cvService) =>
            {
                var user = await cvService.GetUserByIdAsync(id);
                return Results.Ok(user);
            }
        )
        .WithName("GetUserById")
        .WithTags("Users");


                // Retrieve all cvs that include any of the wanted skills
        app.MapPost(
                "/users/skills",
                async (ICvService cvService, SkillRequest request) =>
                {
                    var users = await cvService.GetUsersWithDesiredSkillsAsync(request.WantedSkills);
                    return Results.Ok(users);
                }
            )
            .WithName("GetUsersWithDesiredSkill")
            .WithTags("Users");

        // GET /users/{id:guid}/experiences -> return the user with the experiences
        app.MapGet(
            "/users/{id:guid}/experiences",
            async (Guid id, ICvService cvService) =>
            {
                var user = await cvService.GetExperiencesByUserAsync(id);
                return Results.Ok(user);
            }
        )
        .WithName("GetExperiencesByUser")
        .WithTags("Users");
    }
    

}
