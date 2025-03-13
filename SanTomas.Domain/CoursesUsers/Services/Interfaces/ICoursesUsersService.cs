using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.CoursesUsers.Services.Commands;

namespace SanTomas.Domain.CoursesUsers.Services.Interfaces;

public interface ICoursesUsersService
{
    CourseUser Instantiate(CourseUserInsertCommand command);
    CourseUser Insert(CourseUserInsertCommand command);
    CourseUser GetById(int id);
    CourseUser Update(int id, CourseUserUpdateCommand command);
    CourseUser Delete(int id);
}