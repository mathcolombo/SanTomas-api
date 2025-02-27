using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.MainCategories.Entities;
using Xunit;
using FizzWare.NBuilder;

namespace SanTomas.Domain.Tests.Categories.Entities;

public class CategoryTests
{
    private readonly Category sut;
    private readonly MainCategory mainCategory;

    public CategoryTests()
    {
        mainCategory = Builder<MainCategory>.CreateNew().Build();
        sut = Builder<Category>.CreateNew().With(x => x.MainCategory, mainCategory).Build();
    }
    
    public class Constructor : CategoryTests
    {
        [Fact]
        public void When_ParametersValid_Hope_CategoryInstantiated()
        {
            string categoryName = "categoria teste";
            Category category = new(categoryName, mainCategory);
            Assert.Equal(category.CategoryName, categoryName);
            Assert.IsType<Category>(category);
        }
    }

    public class SetCategoryNameMethod : CategoryTests
    {
        public static IEnumerable<object[]> InvalidCategoriesNames()
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { "        " };
            yield return new object[] {new string('*', 51)};
        }

        [Fact]
        public void When_CategoryNameValid_Hope_UpdateCategoryName()
        {
            string categoryName = "Categoria Testes";
            sut.SetCategoryName(categoryName);
            Assert.Equal(sut.CategoryName, categoryName);
        }
        
        [Theory]
        [MemberData(nameof(InvalidCategoriesNames))]
        public void When_CategoryNameInvalid_Hope_Exception(string invalidCategoryName)
        {
            Assert.Throws<Exception>(() => sut.SetCategoryName(invalidCategoryName));
        }
    }
    
    public class SetMainCategoryMethod : CategoryTests
    {
        [Fact]
        public void When_MainCategoryValid_Hope_UpdateMainCategoryAndMainCategoryId()
        {
            sut.SetMainCategory(mainCategory);
            Assert.Equal(sut.MainCategory, mainCategory);
            Assert.Equal(sut.MainCategoryId, mainCategory.Id);
        }
        
        [Fact]
        public void When_MainCategoryInvalid_Hope_Exception()
        {
            Assert.Throws<Exception>(() => sut.SetMainCategory(null));
        }
    }
}