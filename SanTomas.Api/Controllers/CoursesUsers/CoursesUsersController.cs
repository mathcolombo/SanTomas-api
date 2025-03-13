using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.CoursesUsers.Dtos.Requests;
using SanTomas.Application.CoursesUsers.Dtos.Responses;
using SanTomas.Application.CoursesUsers.Services.Interfaces;

namespace SanTomas_Api.Controllers.CoursesUsers;

[ApiController]
[Route("api/courses-users")]
public class CoursesUsersController : Controller
{
    private readonly ICoursesUsersApplicationService _coursesUsersApplicationService;

    public CoursesUsersController(ICoursesUsersApplicationService coursesUsersApplicationService)
    {
        _coursesUsersApplicationService = coursesUsersApplicationService;
    }

    [HttpPost]
    public ActionResult<CourseUserResponse> Insert([FromBody] CourseUserInsertRequest request)
    {
        var response = _coursesUsersApplicationService.Insert(request);
        return Ok(response);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<CourseUserResponse> GetById(int id)
    {
        var response = _coursesUsersApplicationService.GetById(id);
        return Ok(response);
    }
    
    [HttpPut("{id:int}")]
    public ActionResult<CourseUserResponse> Update(int id, [FromBody] CourseUserUpdateRequest request)
    {
        var response = _coursesUsersApplicationService.Update(id, request);
        return Ok(response);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult<CourseUserResponse> Delete(int id)
    {
        var response = _coursesUsersApplicationService.Delete(id);
        return Ok(response);
    }
}