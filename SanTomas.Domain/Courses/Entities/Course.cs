using SanTomas.Domain.CoursesCategories.Entities;
using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.Platforms.Entities;

namespace SanTomas.Domain.Courses.Entities;

public class Course
{
    public int Id { get; protected set; }
    public string? CourseName { get; protected set; }
    public string? Url { get; protected set; }
    public int PlatformId { get; protected set; }
    public decimal Hours { get; protected set; }
    
    public ICollection<CourseCategory>? CoursesCategories { get; protected set; }
    public ICollection<CourseUser>? CoursesUsers { get; protected set; }
    public Platform? Platform { get; protected set; }

    public Course()
    {
        CoursesCategories = new List<CourseCategory>();
        CoursesUsers = new List<CourseUser>();
    }
}