﻿using SanTomas.Domain.MainCategories.Entities;
using SanTomas.Domain.MainCategories.Repositories.Interfaces;
using SanTomas.Domain.MainCategories.Services.Interfaces;

namespace SanTomas.Domain.MainCategories.Services;

public class MainCategoriesService : IMainCategoriesService
{
    private readonly IMainCategoriesRepository _mainCategoriesRepository;

    public MainCategoriesService(IMainCategoriesRepository mainCategoriesRepository)
    {
        _mainCategoriesRepository = mainCategoriesRepository;
    }
    
    public MainCategory Instantiate(string mainCategoryName) => new MainCategory(mainCategoryName);

    public MainCategory Insert(string mainCategoryName)
    {
        var mainCategory = Instantiate(mainCategoryName);
        return _mainCategoriesRepository.Insert(mainCategory);
    }

    public MainCategory GetById(int id) => _mainCategoriesRepository.GetById(id) ?? throw new NullReferenceException("Categoria principal não foi encontrada!");

    public MainCategory Update(int id, string mainCategoryName)
    {
        var mainCategory = GetById(id);
        mainCategory.SetMainCategoryName(mainCategoryName);
        return _mainCategoriesRepository.Update(mainCategory);
    }

    public MainCategory Delete(int id)
    {
        var mainCategory = GetById(id);
        _mainCategoriesRepository.Delete(mainCategory);
        return mainCategory;
    }
}