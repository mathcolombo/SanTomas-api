using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.Courses.Services.Commands;

namespace SanTomas.Domain.Courses.Services.Interfaces;

public interface ICoursesService
{
    Course Instantiate(CourseInsertCommand command);
    Course Insert(CourseInsertCommand command);
    Course GetById(int id);
    Course Update(int id, CourseUpdateCommand command);
    Course Delete(int id);
}