using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.Categories.Dtos.Requests;
using SanTomas.Application.Categories.Dtos.Responses;
using SanTomas.Application.Categories.Services.Interfaces;

namespace SanTomas_Api.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesApplicationService _categoriesApplicationService;

    public CategoriesController(ICategoriesApplicationService categoriesApplicationService)
    {
        _categoriesApplicationService = categoriesApplicationService;
    }
    
    /// <summary>
    /// Insert the category
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Action Result - CategoryResponse</returns>
    [HttpPost]
    public ActionResult<CategoryResponse> Insert([FromBody] CategoryInsertRequest request)
    {
        var response = _categoriesApplicationService.Insert(request);
        return Ok(response);
    }
    
    /// <summary>
    /// Get the category
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action Result - CategoryResponse</returns>
    [HttpGet("{id:int}")]
    public ActionResult<CategoryResponse> GetById(int id)
    {
        var response = _categoriesApplicationService.GetById(id);
        return Ok(response);
    }
    
    /// <summary>
    /// Update the category
    /// </summary>
    /// <param name="id, request"></param>
    /// <returns>Action Result - CategoryResponse</returns>
    [HttpPut("{id:int}")]
    public ActionResult<CategoryResponse> Update(int id, [FromBody] CategoryUpdateRequest request)
    {
        var response = _categoriesApplicationService.Update(id, request);
        return Ok(response);
    }
    
    /// <summary>
    /// Delete the category
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action Result - CategoryResponse</returns>
    [HttpDelete("{id:int}")]
    public ActionResult<CategoryResponse> Delete(int id)
    {
        var response = _categoriesApplicationService.Delete(id);
        return Ok(response);
    }
}