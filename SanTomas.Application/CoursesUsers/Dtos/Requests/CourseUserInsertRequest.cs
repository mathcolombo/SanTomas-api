namespace SanTomas.Application.CoursesUsers.Dtos.Requests;

public record CourseUserInsertRequest(int CourseId, int UserId, DateTime? StartDate, DateTime? CompletionDate, int Status, decimal? HoursWorked);