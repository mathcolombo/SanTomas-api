using SanTomas.Application.CoursesUsers.Dtos.Requests;
using SanTomas.Application.CoursesUsers.Dtos.Responses;

namespace SanTomas.Application.CoursesUsers.Services.Interfaces;

public interface ICoursesUsersApplicationService
{
    CourseUserResponse Insert(CourseUserInsertRequest request);
    CourseUserResponse GetById(int id);
    CourseUserResponse Update(int id, CourseUserUpdateRequest request);
    CourseUserResponse Delete(int id);
}