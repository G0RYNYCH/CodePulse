using CodePulse.Models.Domain;

namespace CodePulse.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
}