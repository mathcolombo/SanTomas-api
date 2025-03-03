using SanTomas.Domain.MainCategories.Entities;

namespace SanTomas.Domain.MainCategories.Services.Interfaces;

public interface IMainCategoriesService
{
    MainCategory Instantiate(string mainCategoryName);
    MainCategory Insert(string mainCategoryName);
    MainCategory GetById(int id);
    MainCategory Update();
    MainCategory Delete(int id);
}