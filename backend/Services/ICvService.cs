﻿using backend.Data.Models;

namespace backend.Services;

public interface ICvService
{
    // Users
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetUsersWithDesiredSkillsAsync(IEnumerable<string> desiredTechnologies);

    Task<IEnumerable<Experience>> GetAllExperiencesAsync();
    Task<Experience?> GetExperienceByIdAsync(Guid id);
    Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type);

    Task<IEnumerable<Experience>> GetExperiencesByUserAsync(Guid userId);
}
