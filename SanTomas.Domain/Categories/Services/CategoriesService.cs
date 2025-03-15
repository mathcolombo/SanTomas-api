using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Categories.Repositories.Interfaces;
using SanTomas.Domain.Categories.Services.Interfaces;
using SanTomas.Domain.MainCategories.Services.Interfaces;

namespace SanTomas.Domain.Categories.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IMainCategoriesService _mainCategoriesService;

    public CategoriesService(ICategoriesRepository categoriesRepository,
        IMainCategoriesService mainCategoriesService)
    {
        _categoriesRepository = categoriesRepository;
        _mainCategoriesService = mainCategoriesService;
    }
    
    public Category Instantiate(string categoryName, int mainCategoryId)
    {
        var mainCategory = _mainCategoriesService.GetById(mainCategoryId);
        var category = new Category(categoryName, mainCategory);
        return category;
    }

    public Category Insert(string categoryName, int mainCategoryId)
    {
        var category = Instantiate(categoryName, mainCategoryId);
        return _categoriesRepository.Insert(category);
    }

    public Category GetById(int id) => _categoriesRepository.GetById(id) ?? throw new NullReferenceException("Categoria não foi encontrada!");

    public Category Update(int id, string categoryName, int mainCategoryId)
    {
        var category = GetById(id);
        var mainCategory = _mainCategoriesService.GetById(mainCategoryId);
        
        category.SetCategoryName(categoryName);
        category.SetMainCategory(mainCategory);
        return _categoriesRepository.Update(category);
    }

    public Category Delete(int id)
    {
        var category = GetById(id);
        _categoriesRepository.Delete(category);
        return category;
    }
}