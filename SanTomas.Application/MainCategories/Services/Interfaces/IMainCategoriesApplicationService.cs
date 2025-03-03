using SanTomas.Application.MainCategories.Dtos.Requests;
using SanTomas.Application.MainCategories.Dtos.Responses;

namespace SanTomas.Application.MainCategories.Services.Interfaces;

public interface IMainCategoriesApplicationService
{
    MainCategoryResponse Insert(MainCategoryInsertRequest request);
}