using SanTomas.Domain.Categories.Entities;

namespace SanTomas.Domain.Courses.Entities;

public class CourseCategory
{
    public int Id { get; protected set; }
    public int CourseId { get; protected set; }
    public int CategoryId { get; protected set; }
    
    public Course? Course { get; protected set; }
    public Category? Category { get; protected set; }
}