using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.Platforms.Entities;

namespace SanTomas.Domain.Courses.Entities;

public class Course
{
    public int Id { get; protected set; }
    public string CourseName { get; protected set; }
    public string Url { get; protected set; }
    public int PlatformId { get; protected set; }
    public decimal Hours { get; protected set; }
    
    public ICollection<CourseCategory>? CoursesCategories { get; protected set; }
    public ICollection<CourseUser>? CoursesUsers { get; protected set; }
    public Platform? Platform { get; protected set; }

    public Course() {}
    
    public Course(string courseName,
        string url,
        Platform platform,
        decimal hours)
    {
        CoursesCategories = new List<CourseCategory>();
        CoursesUsers = new List<CourseUser>();
        SetCourseName(courseName);
        SetUrl(url);
        SetPlatform(platform);
        SetHours(hours);
    }

    public void SetCourseName(string courseName)
    {
        if (string.IsNullOrWhiteSpace(courseName))
            throw new ArgumentNullException(nameof(courseName));
        if(courseName.Length > 255)
            throw new ArgumentOutOfRangeException(nameof(courseName));
        
        CourseName = courseName;
    }

    public void SetUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));
        if(url.Length > 255)
            throw new ArgumentOutOfRangeException(nameof(url));
        
        Url = url;
    }

    public void SetPlatform(Platform platform)
    {
        Platform = platform;
    }

    public void SetHours(decimal hours)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(hours);
        Hours = hours;
    }
}