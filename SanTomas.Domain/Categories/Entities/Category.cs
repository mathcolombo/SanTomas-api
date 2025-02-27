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
    public ICollection<CourseCategory>? CoursesCategories { get; protected set; }

    public Category() {}
    
    public Category(string categoryName,
        MainCategory mainCategory)
    {
        CoursesCategories = new List<CourseCategory>();
        SetCategoryName(categoryName);
        SetMainCategory(mainCategory);
    }

    public void SetCategoryName(string categoryName)
    {
        const int MAXIMUM_SIZE_CHARACTERES_CATEGORYNAME = 50;
        
        if (string.IsNullOrWhiteSpace(categoryName))
            throw new Exception("Categoria não pode ser nula");
        if (categoryName.Length > MAXIMUM_SIZE_CHARACTERES_CATEGORYNAME)
            throw new Exception($"Tamanho de caracteres inválido: máx = {MAXIMUM_SIZE_CHARACTERES_CATEGORYNAME}");

        CategoryName = categoryName;
    }
    
    public void SetMainCategory(MainCategory mainCategory)
    {
        if (mainCategory is null)
            throw new Exception("Categoria principal não pode ser nula");
            
        MainCategory = mainCategory;
        MainCategoryId = mainCategory.Id;
    }
}