using AutoMapper;
using Microsoft.Extensions.Logging;
using SanTomas.Application.Categories.Dtos.Requests;
using SanTomas.Application.Categories.Dtos.Responses;
using SanTomas.Application.Categories.Services.Interfaces;
using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Categories.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.Categories.Services;

public class CategoriesApplicationService : ICategoriesApplicationService
{
    private readonly ICategoriesService _categoriesService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CategoriesApplicationService> _logger;

    public CategoriesApplicationService(ICategoriesService categoriesService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<CategoriesApplicationService> logger)
    {
        _categoriesService = categoriesService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    
    public CategoryResponse Insert(CategoryInsertRequest request)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var category = _categoriesService.Insert(request.CategoryName, request.MainCategoryId);
            _unitOfWork.Commit();
            return _mapper.Map<CategoryResponse>(category);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            _logger.LogError($"Ocorreu um erro ao inserir uma nova categoria: {e.Message}");
            throw;
        }
    }

    public CategoryResponse GetById(int id)
    {
        var category = _categoriesService.GetById(id);
        Console.WriteLine($">>>>>>>>> {category.MainCategory} > {category.MainCategoryId}");
        return _mapper.Map<CategoryResponse>(category);
    }

    public CategoryResponse Update(int id, CategoryUpdateRequest request)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var category = _categoriesService.Update(id, request.CategoryName, request.MainCategoryId);
            _unitOfWork.Commit();
            return _mapper.Map<CategoryResponse>(category);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            _logger.LogError($"Ocorreu um erro ao atualizar a categoria {id}: {e.Message}");
            throw;
        }
    }

    public CategoryResponse Delete(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var category = _categoriesService.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<CategoryResponse>(category);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            _logger.LogError($"Ocorreu um erro ao deletar a categoria {id}: {e.Message}");
            throw;
        }
    }
}