﻿using CodePulse.Data;
using CodePulse.Models.Domain;
using CodePulse.Repositories.Interfaces;

namespace CodePulse.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return category;
    }
}