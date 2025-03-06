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
    
    [HttpPost]
    public ActionResult<MainCategoryResponse> Insert([FromBody] MainCategoryInsertRequest request)
    {
       MainCategoryResponse response = _mainCategoriesApplicationService.Insert(request);
       return Ok(response);
    }

    [HttpGet("{id:int}")]
    public ActionResult<MainCategoryResponse> GetById(int id)
    {
        MainCategoryResponse response = _mainCategoriesApplicationService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public ActionResult<MainCategoryResponse> Update(int id, [FromBody] MainCategoryUpdateRequest request)
    {
        MainCategoryResponse response = _mainCategoriesApplicationService.Update(id, request);
        return Ok(response);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult<MainCategoryResponse> Delete(int id)
    {
        MainCategoryResponse response = _mainCategoriesApplicationService.Delete(id);
        return Ok(response);
    }
}