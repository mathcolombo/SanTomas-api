namespace SanTomas.Domain.Courses.Services.Commands;

public class CourseInsertCommand
{
    public string CourseName { get; set; }
    public string Url { get; set; }
    public int PlatformId { get; set; }
    public decimal Hours { get; set; }
}