using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Certificates.Entities;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.CoursesUsers.Enums;
using SanTomas.Domain.Users.Entities;

namespace SanTomas.Domain.CoursesUsers.Entities;

public class CourseUser
{
    public int Id { get; protected set; }
    public int CourseId { get; protected set; }
    public int UserId { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime CompletionDate { get; protected set; }
    public StatusCursoEnum Status { get; protected set; }
    public decimal HoursWorked { get; protected set; }
    public decimal Progress { get; protected set; }
    
    // Navigations EF
    public Course? Course { get; protected set; }
    public User? User { get; protected set; }
    public Certificate? Certificate { get; protected set; }
}