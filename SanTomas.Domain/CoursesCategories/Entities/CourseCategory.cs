using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Courses.Entities;

namespace SanTomas.Domain.CoursesCategories.Entities;

public class CourseCategory
{
    public int Id { get; protected set; }
    public int CourseId { get; protected set; }
    public int CategoryId { get; protected set; }
    
    public Course? Course { get; protected set; }
    public Category? Category { get; protected set; }
}