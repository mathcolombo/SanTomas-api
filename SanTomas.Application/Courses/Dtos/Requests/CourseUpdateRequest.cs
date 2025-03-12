namespace SanTomas.Application.Courses.Dtos.Requests;

public record CourseUpdateRequest(string CourseName, string Url, int PlatformId, decimal Hours);