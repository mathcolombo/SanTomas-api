using System.ComponentModel.DataAnnotations;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.CoursesUsers.Entities;

namespace SanTomas.Domain.Users.Entities;

public class User
{
    public int Id { get; protected set; }
    public string? FullName { get; protected set; }
    public string? Email { get; protected set; }
    public string? Password { get; protected set; }
    public DateOnly RegisterDate { get; protected set; }
    
    public ICollection<CourseUser>? CoursesUsers { get; protected set; }
    
    public User()
    {
        CoursesUsers = new List<CourseUser>();
    }
}