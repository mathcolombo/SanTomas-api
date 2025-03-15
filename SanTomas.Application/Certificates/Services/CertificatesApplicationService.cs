using AutoMapper;
using Microsoft.Extensions.Logging;
using SanTomas.Application.Certificates.Dtos.Requests;
using SanTomas.Application.Certificates.Dtos.Responses;
using SanTomas.Application.Certificates.Services.Interfaces;
using SanTomas.Domain.Certificates.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.Certificates.Services;

public class CertificatesApplicationService : ICertificatesApplicationService
{
    private readonly ICertificatesService _certificatesService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CertificatesApplicationService> _logger;

    public CertificatesApplicationService(ICertificatesService certificatesService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<CertificatesApplicationService> logger)
    {
        _certificatesService = certificatesService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    
    public CertificateResponse Insert(CertificateInsertRequest request)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var certificate = _certificatesService.Insert(request.CourseUserId, request.FilePath);
            _unitOfWork.Commit();
            
            return _mapper.Map<CertificateResponse>(certificate);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public CertificateResponse GetById(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var certificate = _certificatesService.GetById(id);
            _unitOfWork.Commit();
            
            return _mapper.Map<CertificateResponse>(certificate);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public CertificateResponse Delete(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var certificate = _certificatesService.Delete(id);
            _unitOfWork.Commit();
            
            return _mapper.Map<CertificateResponse>(certificate);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}