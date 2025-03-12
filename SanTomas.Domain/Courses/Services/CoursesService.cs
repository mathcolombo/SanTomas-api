using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.Courses.Repositories.Interfaces;
using SanTomas.Domain.Courses.Services.Commands;
using SanTomas.Domain.Courses.Services.Interfaces;
using SanTomas.Domain.Platforms.Services.Interfaces;

namespace SanTomas.Domain.Courses.Services;

public class CoursesService : ICoursesService
{
    private readonly ICoursesRepository _coursesRepository;
    private readonly IPlatformsService _platformService;
    
    public CoursesService(ICoursesRepository coursesRepository, IPlatformsService platformService)
    {
        _coursesRepository = coursesRepository;
        _platformService = platformService;
    }
    
    public Course Instantiate(CourseInsertCommand command)
    {
        var platform = _platformService.GetById(command.PlatformId);
        var course = new Course(command.CourseName, command.Url, platform, command.Hours);
        return course;
    }

    public Course Insert(CourseInsertCommand command)
    {
        var course = Instantiate(command);
        return _coursesRepository.Insert(course);
    }

    public Course GetById(int id) => _coursesRepository.GetById(id) ?? throw new NullReferenceException("Curso não encontrado!");

    public Course Update(int id, CourseUpdateCommand command)
    {
        var course = GetById(id);
        var platform = _platformService.GetById(command.PlatformId);
        
        course.SetCourseName(command.CourseName);
        course.SetUrl(command.Url);
        course.SetPlatform(platform);
        course.SetHours(command.Hours);

        return _coursesRepository.Update(course);
    }

    public Course Delete(int id)
    {
        var course = GetById(id);
        _coursesRepository.Delete(course);
        return course;
    }
}