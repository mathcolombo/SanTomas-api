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
        MainCategory mainCategory = Instantiate(mainCategoryName);
        return _mainCategoriesRepository.Insert(mainCategory);
    }

    public MainCategory GetById(int id)
    {
        throw new NotImplementedException();
    }

    public MainCategory Update()
    {
        throw new NotImplementedException();
    }

    public MainCategory Delete(int id)
    {
        throw new NotImplementedException();
    }
}