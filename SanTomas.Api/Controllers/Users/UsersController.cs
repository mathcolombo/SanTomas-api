using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.Users.Dtos.Requests;
using SanTomas.Application.Users.Dtos.Responses;
using SanTomas.Application.Users.Services.Interfaces;

namespace SanTomas_Api.Controllers.Users;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IUsersApplicationService _usersApplicationService;

    public UsersController(IUsersApplicationService usersApplicationService)
    {
        _usersApplicationService = usersApplicationService;
    }
    
    /// <summary>
    /// Insert the user
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Action Result - UserResponse</returns>
    [HttpPost]
    public ActionResult<UserResponse> Insert([FromBody] UserInsertRequest request)
    {
        var response = _usersApplicationService.Insert(request);
        return Ok(response);
    }
    
    /// <summary>
    /// Get the user
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action Result - UserResponse</returns>
    [HttpGet("{id:int}")]
    public ActionResult<UserResponse> GetById(int id)
    {
        var response = _usersApplicationService.GetById(id);
        return Ok(response);
    }
    
    /// <summary>
    /// Update the user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>Action Result - UserResponse</returns>
    [HttpPut("{id:int}")]
    public ActionResult<UserResponse> Update(int id, [FromBody] UserUpdateRequest request)
    {
        var response = _usersApplicationService.Update(id, request);
        return Ok(response);
    }
    
    /// <summary>
    /// Delete the user
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Action Result - UserResponse</returns>
    [HttpDelete("{id:int}")]
    public ActionResult<UserResponse> Delete(int id)
    {
        var response = _usersApplicationService.Delete(id);
        return Ok(response);
    }
}