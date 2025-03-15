using SanTomas.Domain.CoursesUsers.Enums;

namespace SanTomas.Domain.CoursesUsers.Services.Commands;

public class CourseUserInsertCommand
{
    public int CourseId { get; set; }
    public int UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public StatusCourseEnum Status { get; set; }
    public decimal? HoursWorked { get; set; }
}