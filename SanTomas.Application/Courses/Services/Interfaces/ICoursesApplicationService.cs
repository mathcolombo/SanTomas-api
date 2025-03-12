using SanTomas.Application.Courses.Dtos.Requests;
using SanTomas.Application.Courses.Dtos.Responses;

namespace SanTomas.Application.Courses.Services.Interfaces;

public interface ICoursesApplicationService
{
    CourseResponse Insert(CourseInsertRequest request);
    CourseResponse GetById(int id);
    CourseResponse Update(int id, CourseUpdateRequest request);
    CourseResponse Delete(int id);
}