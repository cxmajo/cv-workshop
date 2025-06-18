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
                    return cvService.GetAllExperiencesAsync();
                }
            )
            .WithName("GetAllExperiences")
            .WithTags("Experiences");

        // GET /experiences/{id}
        app.MapGet(
                "/experiences/{id:guid}",
                (Guid id, ICvService cvService) =>
                {
                    return cvService.GetExperienceByIdAsync(id);
                }
            )
            .WithName("GetExperienceById")
            .WithTags("Experiences");

        // GET /experiences/type/{type}
        app.MapGet(
                "/experiences/type/{type}",
                (string type, ICvService cvService) =>
                {
                    return cvService.GetExperiencesByTypeAsync(type);
                }
            )
            .WithName("GetExperiencesByType")
            .WithTags("Experiences");
    }
}
