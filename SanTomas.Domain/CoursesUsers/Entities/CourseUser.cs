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
    public DateTime? StartDate { get; protected set; }
    public DateTime? CompletionDate { get; protected set; }
    public StatusCourseEnum Status { get; protected set; }
    public decimal? HoursWorked { get; protected set; }
    public decimal? Progress { get; protected set; }
    
    // Navigations EF
    public Course Course { get; protected set; }
    public User User { get; protected set; }
    public Certificate? Certificate { get; protected set; }
    
    public CourseUser() {}

    public CourseUser(Course course,
        User user,
        DateTime? startDate,
        DateTime? completionDate,
        StatusCourseEnum status,
        decimal? hoursWorked)
    {
        SetCourse(course);
        SetUser(user);
        SetStartDate(startDate);
        SetCompletionDate(completionDate);
        SetStatus(status);
        SetHoursWorked(hoursWorked);
    }

    public void SetCourse(Course course)
    {
        Course = course;
    }

    public void SetUser(User user)
    {
        User = user;
    }

    public void SetStartDate(DateTime? startDate)
    {
        if (startDate is null)
            return;
        if (startDate <= DateTime.MinValue)
            throw new ArgumentOutOfRangeException();
        
        StartDate = startDate;
    }

    public void SetCompletionDate(DateTime? completionDate)
    {
        if (completionDate is null)
            return;
        if (StartDate is null)
            throw new Exception("Por favor, informe a data inicial do curso antes da data de término");
        if(completionDate < StartDate)
            throw new Exception("Data de término não pode ser menor que a data inicial do curso");
        
        CompletionDate = completionDate;
    }

    public void SetStatus(StatusCourseEnum status)
    {
        Status = status;
    }

    public void SetHoursWorked(decimal? hoursWorked)
    {
        if(hoursWorked is null)
            return;
        if(hoursWorked <= 0)
            throw new ArgumentOutOfRangeException();
        
        HoursWorked = hoursWorked;
    }
}