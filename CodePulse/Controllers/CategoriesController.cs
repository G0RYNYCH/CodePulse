using CodePulse.Data;
using CodePulse.Models.Domain;
using CodePulse.Models.Dto;
using CodePulse.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            UrlHandle = dto.UrlHandle
        };

        await _categoryRepository.CreateAsync(category);

        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Ok(categoryDto);
    }
}