using SanTomas.Application.Platforms.Dtos.Responses;

namespace SanTomas.Application.Courses.Dtos.Responses;

public record CourseResponse(int Id, string CourseName, string Url, PlatformResponse Platform, decimal Hours);