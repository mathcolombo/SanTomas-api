using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.MainCategories.Dtos.Requests;
using SanTomas.Application.MainCategories.Dtos.Responses;
using SanTomas.Application.MainCategories.Services.Interfaces;

namespace SanTomas_Api.Controllers.MainCategories;

[ApiController]
[Route("api/[controller]")]
public class MainCategoriesController : ControllerBase
{
    private readonly IMainCategoriesApplication _mainCategoriesApplication;

    public MainCategoriesController(IMainCategoriesApplication mainCategoriesApplication)
    {
        _mainCategoriesApplication = mainCategoriesApplication;
    }
    
    [HttpPost]
    public ActionResult<MainCategoryResponse> Insert([FromBody] MainCategoryInsertRequest request)
    {
       MainCategoryResponse? response = _mainCategoriesApplication.Insert(request);
       return Ok(response);
    }
}