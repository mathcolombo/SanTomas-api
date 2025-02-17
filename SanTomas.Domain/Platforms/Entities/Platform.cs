using System.ComponentModel.DataAnnotations;
using SanTomas.Domain.Courses.Entities;

namespace SanTomas.Domain.Platforms.Entities;

public class Platform
{
    public int Id { get; protected set; }
    public string? PlatformName { get; protected set; }
    public string? Url { get; protected set; }
    
    public ICollection<Course>? Courses { get; protected set; }

    public Platform()
    {
        Courses = new List<Course>();
    }
}