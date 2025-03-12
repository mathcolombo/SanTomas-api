using AutoMapper;
using SanTomas.Application.Courses.Dtos.Requests;
using SanTomas.Application.Courses.Dtos.Responses;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.Courses.Services.Commands;

namespace SanTomas.Application.Courses.Profiles;

public class CoursesProfile : Profile
{
    public CoursesProfile()
    {
        CreateMap<Course, CourseResponse>();
        CreateMap<CourseInsertRequest, CourseInsertCommand>();
        CreateMap<CourseUpdateRequest, CourseUpdateCommand>();
    }
}