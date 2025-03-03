using SanTomas.Application.Categories.Dtos.Requests;
using SanTomas.Application.Categories.Dtos.Responses;

namespace SanTomas.Application.Categories.Services.Interfaces;

public interface ICategoriesApplicationService
{
    CategoryResponse Insert(CategoryInsertRequest request);
    CategoryResponse GetById(int id);
    CategoryResponse Update(int id, CategoryUpdateRequest request);
    CategoryResponse Delete(int id);
}