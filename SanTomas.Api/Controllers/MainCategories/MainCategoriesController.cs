using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.MainCategories.Dtos.Requests;
using SanTomas.Application.MainCategories.Dtos.Responses;
using SanTomas.Application.MainCategories.Services.Interfaces;

namespace SanTomas_Api.Controllers.MainCategories;

[ApiController]
[Route("api/[controller]")]
public class MainCategoriesController : ControllerBase
{
    private readonly IMainCategoriesApplicationService _mainCategoriesApplicationService;

    public MainCategoriesController(IMainCategoriesApplicationService mainCategoriesApplicationService)
    {
        _mainCategoriesApplicationService = mainCategoriesApplicationService;
    }
    
    /// <summary>
    /// Insert the main category
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Action Result - MainCategoryResponse</returns>
    [HttpPost]
    public ActionResult<MainCategoryResponse> Insert([FromBody] MainCategoryInsertRequest request)
    {
       MainCategoryResponse response = _mainCategoriesApplicationService.Insert(request);
       return Ok(response);
    }
    
    /// <summary>
    /// Get the main category
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action Result - MainCategoryResponse</returns>
    [HttpGet("{id:int}")]
    public ActionResult<MainCategoryResponse> GetById(int id)
    {
        MainCategoryResponse response = _mainCategoriesApplicationService.GetById(id);
        return Ok(response);
    }

    /// <summary>
    /// Update the main category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>Action Result - MainCategoryResponse</returns>
    [HttpPut("{id:int}")]
    public ActionResult<MainCategoryResponse> Update(int id, [FromBody] MainCategoryUpdateRequest request)
    {
        MainCategoryResponse response = _mainCategoriesApplicationService.Update(id, request);
        return Ok(response);
    }
    
    /// <summary>
    /// Delete the main category
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action Result - MainCategoryResponse</returns>
    [HttpDelete("{id:int}")]
    public ActionResult<MainCategoryResponse> Delete(int id)
    {
        MainCategoryResponse response = _mainCategoriesApplicationService.Delete(id);
        return Ok(response);
    }
}