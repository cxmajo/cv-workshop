using backend.Data.Mappers;
using backend.Services;

namespace backend.Endpoints;

public static class ExperienceEndpoints
{
    public static void MapExperienceEndpoints(this WebApplication app)
    {
        // GET /experiences
        app.MapGet(
                "/experiences",
                (ICvService cvService) =>
                {
                    // TODO: Oppgave 2

                    return Results.Ok();
                }
            )
            .WithName("GetAllExperiences")
            .WithTags("Experiences");

        // GET /experiences/{id}
        app.MapGet(
                "/experiences/{id:guid}",
                (Guid id, ICvService cvService) =>
                {
                    // TODO: Oppgave 2

                    return Results.Ok();
                }
            )
            .WithName("GetExperienceById")
            .WithTags("Experiences");

        // GET /experiences/type/{type}
        app.MapGet(
                "/experiences/type/{type}",
                (string type, ICvService cvService) =>
                {
                    // TODO: Oppgave 3

                    return Results.Ok();
                }
            )
            .WithName("GetExperiencesByType")
            .WithTags("Experiences");
    }
}
