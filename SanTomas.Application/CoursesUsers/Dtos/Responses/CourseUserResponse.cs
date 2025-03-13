using SanTomas.Application.Courses.Dtos.Responses;
using SanTomas.Application.Users.Dtos.Responses;

namespace SanTomas.Application.CoursesUsers.Dtos.Responses;

public record CourseUserResponse(int Id, CourseResponse Course, UserResponse User, DateTime StartDate, DateTime CompletionDate, int Status, decimal HoursWorked, decimal Progress);