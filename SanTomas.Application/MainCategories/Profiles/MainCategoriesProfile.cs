using AutoMapper;
using SanTomas.Application.MainCategories.Dtos.Responses;
using SanTomas.Domain.MainCategories.Entities;

namespace SanTomas.Application.MainCategories.Profiles;

public class MainCategoriesProfile : Profile
{
    public MainCategoriesProfile()
    {
        CreateMap<MainCategory, MainCategoryResponse>();
    }
}