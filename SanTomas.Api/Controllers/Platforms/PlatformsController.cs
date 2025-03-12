using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.Platforms.Dtos.Requests;
using SanTomas.Application.Platforms.Dtos.Responses;
using SanTomas.Application.Platforms.Services.Interfaces;

namespace SanTomas_Api.Controllers.Platforms;

[ApiController]
[Route("api/platforms")]
public class PlatformsController : Controller
{
    private readonly IPlatformsApplicationService _platformsApplicationService;

    public PlatformsController(IPlatformsApplicationService platformsApplicationService)
    {
        _platformsApplicationService = platformsApplicationService;
    }

    [HttpPost]
    public ActionResult<PlatformResponse> Insert([FromBody] PlatformInsertRequest request)
    {
        var response = _platformsApplicationService.Insert(request);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public ActionResult<PlatformResponse> GetById(int id)
    {
        var response = _platformsApplicationService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public ActionResult<PlatformResponse> Update(int id, [FromBody] PlatformUpdateRequest request)
    {
        var response = _platformsApplicationService.Update(id, request);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<PlatformResponse> Delete(int id)
    {
        var response = _platformsApplicationService.Delete(id);
        return Ok(response);
    }
}