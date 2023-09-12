using CodePulse.Data;
using CodePulse.Models.Domain;
using CodePulse.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CategoriesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            UrlHandle = dto.UrlHandle
        };

        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Ok(categoryDto);
    }
}