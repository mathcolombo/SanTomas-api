using SanTomas.Domain.Courses.Repositories.Interfaces;
using SanTomas.Domain.Courses.Services.Interfaces;
using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.CoursesUsers.Repositories.Interfaces;
using SanTomas.Domain.CoursesUsers.Services.Commands;
using SanTomas.Domain.CoursesUsers.Services.Interfaces;
using SanTomas.Domain.Users.Services.Interfaces;

namespace SanTomas.Domain.CoursesUsers.Services;

public class CoursesUsersService : ICoursesUsersService
{
    private readonly ICoursesUsersRepository _coursesUsersRepository;
    private readonly ICoursesService _coursesService;
    private readonly IUsersService _usersService;

    public CoursesUsersService(ICoursesUsersRepository coursesUsersRepository,
        ICoursesService coursesService,
        IUsersService usersService)
    {
        _coursesUsersRepository = coursesUsersRepository;
        _coursesService = coursesService;
        _usersService = usersService;
    }
    
    public CourseUser Instantiate(CourseUserInsertCommand command)
    {
        var course = _coursesService.GetById(command.CourseId);
        var user = _usersService.GetById(command.UserId);

        return new(course, user, command.StartDate, command.CompletionDate, command.Status, command.HoursWorked);
    }

    public CourseUser Insert(CourseUserInsertCommand command)
    {
        var courseUser = Instantiate(command);
        return _coursesUsersRepository.Insert(courseUser);
    }

    public CourseUser GetById(int id) => _coursesUsersRepository.GetById(id) ?? throw new Exception("Curso não encontrado");


    public CourseUser Update(int id, CourseUserUpdateCommand command)
    {
        var courseUser = GetById(id);
        
        courseUser.SetStartDate(command.StartDate);
        courseUser.SetCompletionDate(command.CompletionDate);
        courseUser.SetStatus(command.Status);
        courseUser.SetHoursWorked(command.HoursWorked);
        
        return _coursesUsersRepository.Update(courseUser);
    }

    public CourseUser Delete(int id)
    {
        var courseUser = GetById(id);
        _coursesUsersRepository.Delete(courseUser);
        return courseUser;
    }
}