using AutoMapper;
using SanTomas.Application.Categories.Dtos.Requests;
using SanTomas.Application.Categories.Dtos.Responses;
using SanTomas.Domain.Categories.Entities;

namespace SanTomas.Application.Categories.Profiles;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Category, CategoryResponse>();
    }
}