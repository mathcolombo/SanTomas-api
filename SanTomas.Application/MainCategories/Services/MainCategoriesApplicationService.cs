using AutoMapper;
using Microsoft.Extensions.Logging;
using SanTomas.Application.MainCategories.Dtos.Requests;
using SanTomas.Application.MainCategories.Dtos.Responses;
using SanTomas.Application.MainCategories.Services.Interfaces;
using SanTomas.Domain.MainCategories.Entities;
using SanTomas.Domain.MainCategories.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.MainCategories.Services;

public class MainCategoriesApplicationService : IMainCategoriesApplicationService
{
    private readonly IMainCategoriesService _mainCategoriesService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<MainCategoriesApplicationService> _logger;

    public MainCategoriesApplicationService(IMainCategoriesService mainCategoriesService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<MainCategoriesApplicationService> logger)
    {
        _mainCategoriesService = mainCategoriesService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    
    public MainCategoryResponse Insert(MainCategoryInsertRequest request)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            MainCategory mainCategory = _mainCategoriesService.Insert(request.MainCategoryName);
            _unitOfWork.Commit();
            
            return _mapper.Map<MainCategoryResponse>(mainCategory);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            _logger.LogError($"Erro ao criar Main Category >> {e.Message}");
        }

        return null;
    }
}