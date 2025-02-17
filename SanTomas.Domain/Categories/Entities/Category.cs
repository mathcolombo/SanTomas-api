using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.CoursesCategories.Entities;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.MainCategories.Entities;

namespace SanTomas.Domain.Categories.Entities;

public class Category
{
    public int Id { get; protected set; }
    public string CategoryName { get; protected set; }
    public int MainCategoryId { get; protected set; }
    
    // Navigations EF
    public MainCategory MainCategory { get; set; }
    public ICollection<CourseCategory> CoursesCategories { get; protected set; }

    public Category()
    {
        CoursesCategories = new List<CourseCategory>();
    }
}