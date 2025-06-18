using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using backend.Data;
using backend.Data.Mappers;
using backend.Data.Models;
using backend.Data.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class CvService(AppDbContext context) : ICvService
{
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users.OrderBy(u => u.Name).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        return await context.Experiences.OrderBy(e => e.StartDate).ToListAsync();
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        return await context.Experiences.FindAsync(id);
    }

    public async Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type)
    {
        return await context.Experiences.Where(e => e.Type == type).OrderBy(e => e.StartDate).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetUsersWithDesiredSkillsAsync(IEnumerable<string> desiredTechnologies)
    {
        var users = await context.Users.ToListAsync();
        return users.Where(u => desiredTechnologies.All(u.Skills.ToString().Split(';').Contains));
    }

    public async Task<IEnumerable<Experience>> GetExperiencesByUserAsync(Guid userId) 
    {
        return await context.Experiences.Where(e => e.UserId == userId).ToListAsync();
    }
}
