using AutoMapper;
using SanTomas.Application.CoursesUsers.Dtos.Requests;
using SanTomas.Application.CoursesUsers.Dtos.Responses;
using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.CoursesUsers.Services.Commands;

namespace SanTomas.Application.CoursesUsers.Profiles;

public class CoursesUsersProfile : Profile
{
    public CoursesUsersProfile()
    {
        CreateMap<CourseUser, CourseUserResponse>();
        CreateMap<CourseUserInsertRequest, CourseUserInsertCommand>();
        CreateMap<CourseUserUpdateRequest, CourseUserUpdateCommand>();
    }
}