namespace SanTomas.Application.Courses.Dtos.Requests;

public record CourseInsertRequest(string CourseName, string Url, int PlatformId, decimal Hours);