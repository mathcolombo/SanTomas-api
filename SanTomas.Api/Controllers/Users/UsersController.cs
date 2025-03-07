using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.Users.Dtos.Requests;
using SanTomas.Application.Users.Dtos.Responses;
using SanTomas.Application.Users.Services.Interfaces;

namespace SanTomas_Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUsersApplicationService _usersApplicationService;

    public UsersController(IUsersApplicationService usersApplicationService)
    {
        _usersApplicationService = usersApplicationService;
    }

    [HttpPost]
    public ActionResult<UserResponse> Insert([FromBody] UserInsertRequest request)
    {
        var response = _usersApplicationService.Insert(request);
        return Ok(response);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<UserResponse> GetById(int id)
    {
        var response = _usersApplicationService.GetById(id);
        return Ok(response);
    }
    
    [HttpPut("{id:int}")]
    public ActionResult<UserResponse> Update(int id, [FromBody] UserUpdateRequest request)
    {
        var response = _usersApplicationService.Update(id, request);
        return Ok(response);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult<UserResponse> Delete(int id)
    {
        var response = _usersApplicationService.Delete(id);
        return Ok(response);
    }
}