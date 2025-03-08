using AutoMapper;
using Microsoft.Extensions.Logging;
using SanTomas.Application.Platforms.Dtos.Requests;
using SanTomas.Application.Platforms.Dtos.Responses;
using SanTomas.Application.Platforms.Services.Interfaces;
using SanTomas.Domain.Platforms.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.Platforms.Services;

public class PlatformsApplicationService : IPlatformsApplicationService
{
    private readonly IPlatformsService _platformsService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<PlatformsApplicationService> _logger;
    
    public PlatformsApplicationService(IPlatformsService platformsService, IUnitOfWork unitOfWork, IMapper mapper, ILogger<PlatformsApplicationService> logger)
    {
        _platformsService = platformsService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    
    public PlatformResponse Insert(PlatformInsertRequest request)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var platform = _platformsService.Insert(request.PlatformName, request.Url);
            _unitOfWork.Commit();
            return _mapper.Map<PlatformResponse>(platform);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }

    }

    public PlatformResponse GetById(int id)
    {
        var platform = _platformsService.GetById(id);
        return _mapper.Map<PlatformResponse>(platform);
    }

    public PlatformResponse Update(int id, PlatformUpdateRequest request)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var platform = _platformsService.Update(id, request.PlatformName, request.Url);
            _unitOfWork.Commit();
            return _mapper.Map<PlatformResponse>(platform);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }

    }

    public PlatformResponse Delete(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var platform = _platformsService.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<PlatformResponse>(platform);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }

    }
}