using AutoMapper;
using SanTomas.Application.Platforms.Dtos.Responses;
using SanTomas.Domain.Platforms.Entities;

namespace SanTomas.Application.Platforms.Profiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        CreateMap<Platform, PlatformResponse>();
    }
}