using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SanTomas.Application.Certificates.Dtos.Requests;
using SanTomas.Application.Certificates.Dtos.Responses;
using SanTomas.Application.Certificates.Services.Interfaces;

namespace SanTomas_Api.Controllers.Certificates;

[ApiController]
[Route("api/certificates")]
public class CertificatesController : Controller
{
    private readonly ICertificatesApplicationService _certificatesApplicationService;

    public CertificatesController(ICertificatesApplicationService certificatesApplicationService)
    {
        _certificatesApplicationService = certificatesApplicationService;
    }

    /// <summary>
    /// Insert the course certificate
    /// </summary>
    /// <param name="request"></param>
    /// <returns>CertificateResponse</returns>
    [HttpPost]
    public ActionResult<CertificateResponse> Insert(CertificateInsertRequest request)
    {
        var response = _certificatesApplicationService.Insert(request);
        return Ok(response);
    }
    
    /// <summary>
    /// Get the course certificate by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>CertificateResponse</returns>
    [HttpGet("{id:int}")]
    public ActionResult<CertificateResponse> GetById(int id)
    {
        var response = _certificatesApplicationService.GetById(id);
        return Ok(response);
    }
    
    /// <summary>
    /// Delete the course certificate
    /// </summary>
    /// <param name="id"></param>
    /// <returns>CertificateResponse</returns>
    [HttpDelete("{id:int}")]
    public ActionResult<CertificateResponse> Delete(int id)
    {
        var response = _certificatesApplicationService.Delete(id);
        return Ok(response);
    }
}