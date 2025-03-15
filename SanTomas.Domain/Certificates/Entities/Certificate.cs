using SanTomas.Domain.CoursesUsers.Entities;

namespace SanTomas.Domain.Certificates.Entities;

public class Certificate
{
    public int Id { get; protected set; }
    public int CourseUserId { get; set; }
    public string FilePath { get; protected set; }
    public DateTime UploadDate { get; protected set; }
    
    // Navigations EF
    public CourseUser? CourseUser { get; protected set; }
}