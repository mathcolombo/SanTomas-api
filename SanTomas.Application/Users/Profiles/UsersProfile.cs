using AutoMapper;
using SanTomas.Application.Users.Dtos.Requests;
using SanTomas.Application.Users.Dtos.Responses;
using SanTomas.Domain.Users.Entities;
using SanTomas.Domain.Users.Services.Commands;

namespace SanTomas.Application.Users.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserInsertRequest, UserInsertCommand>();
        CreateMap<UserUpdateRequest, UserUpdateCommand>();
    }
}