using SanTomas.Application.CoursesUsers.Dtos.Responses;

namespace SanTomas.Application.Certificates.Dtos.Responses;

public record CertificateResponse(int Id, CourseUserResponse CourseUser, string FilePath, DateTime UploadDate);