using SanTomas.Application.MainCategories.Dtos.Responses;

namespace SanTomas.Application.Categories.Dtos.Responses;

public record CategoryResponse(int Id, string CategoryName, MainCategoryResponse MainCategory);