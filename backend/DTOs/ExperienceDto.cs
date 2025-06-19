namespace backend.DTOs;

public enum ExperienceType
{
    Education,
    Work,
    Coach,

    HobbyProject,

    Voluntary,

    Other
}

public record ExperienceDto(
    Guid Id,
    Guid UserId,
    string Title,
    string Role,
    ExperienceType Type,
    DateTime StartDate,
    DateTime? EndDate,
    string Description,
    string? ImageUrl,
    string? Company
);
