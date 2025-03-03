using System.ComponentModel.DataAnnotations;
using SanTomas.Domain.Categories.Entities;

namespace SanTomas.Domain.MainCategories.Entities;

public class MainCategory
{
    public int Id { get; protected set; }
    public string MainCategoryName { get; protected set; }
    
    // Navigations EF
    public ICollection<Category>? Categories { get; set; }

    public MainCategory() {}
    
    public MainCategory(string mainCategoryName)
    {
        Categories = new List<Category>();
        SetMainCategoryName(mainCategoryName);
    }

    public void SetMainCategoryName(string mainCategoryName)
    {
        if(string.IsNullOrWhiteSpace(mainCategoryName))
            throw new ArgumentNullException(nameof(mainCategoryName));
        if(mainCategoryName.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(mainCategoryName));
        
        MainCategoryName = mainCategoryName;
    }
}