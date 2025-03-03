using SanTomas.Domain.Categories.Entities;

namespace SanTomas.Domain.Categories.Services.Interfaces;

public interface ICategoriesService
{
    Category Instantiate(string categoryName, int mainCategoryId);
    Category Insert(string categoryName, int mainCategoryId);
    Category GetById(int id);
    Category Update(int id, string categoryName, int mainCategoryId);
    Category Delete(int id);
}