using Microsoft.AspNetCore.Mvc;

namespace SanTomas_Api.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<string> Recuperar(int id)
    {
        return Ok(id % 2 == 0 ? "Par" : "Ímpar");
    }
}