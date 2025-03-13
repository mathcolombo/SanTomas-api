namespace SanTomas.Application.CoursesUsers.Dtos.Requests;

public record CourseUserUpdateRequest(DateTime? StartDate, DateTime? CompletionDate, int Status, decimal? HoursWorked);