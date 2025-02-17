using System.ComponentModel.DataAnnotations;
using SanTomas.Domain.Categories.Entities;

namespace SanTomas.Domain.MainCategories.Entities;

public class MainCategory
{
    public int Id { get; protected set; }
    public string? MainCategoryName { get; protected set; }
    
    public ICollection<Category>? Categories { get; set; }

    public MainCategory()
    {
        Categories = new List<Category>();
    }
}