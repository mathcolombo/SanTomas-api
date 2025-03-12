using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.Courses.Dtos.Requests;
using SanTomas.Application.Courses.Dtos.Responses;
using SanTomas.Application.Courses.Services.Interfaces;

namespace SanTomas_Api.Controllers.Courses;

[ApiController]
[Route("api/courses")]
public class CoursesController : Controller
{
    private readonly ICoursesApplicationService _coursesApplicationService;

    public CoursesController(ICoursesApplicationService coursesApplicationService)
    {
        _coursesApplicationService = coursesApplicationService;
    }

    [HttpPost]
    public ActionResult<CourseResponse> Insert([FromBody] CourseInsertRequest request)
    {
        var response = _coursesApplicationService.Insert(request);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public ActionResult<CourseResponse> GetById(int id)
    {
        var response = _coursesApplicationService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseResponse> Update(int id, [FromBody] CourseUpdateRequest request)
    {
        var response = _coursesApplicationService.Update(id, request);
        return Ok(response);
    }


    [HttpDelete("{id:int}")]
    public ActionResult<CourseResponse> Delete(int id)
    {
        var response = _coursesApplicationService.Delete(id);
        return Ok(response);
    }
    
}