using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.Categories.Entities;

namespace SanTomas.Infra.Categories.Configurations;

public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.ToTable(c => c.HasComment("Tabela que armazena as categorias de cursos disponíveis"));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único da categoria");
        
        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Nome da categoria do curso. Ex: Angular, C#, Agile, etc");
        builder.HasIndex(c => c.CategoryName)
            .IsUnique()
            .HasDatabaseName("IX_Categories_CategoryName");

        builder.HasOne(c => c.MainCategory)
            .WithMany(mc => mc.Categories)
            .HasForeignKey(c => c.MainCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(c => c.MainCategoryId)
            .IsRequired()
            .HasComment("Referência à categoria principal/pai vinculada à categoria");
        
        // Navigations EF
        builder.HasMany(c => c.CoursesCategories)
            .WithOne(cc => cc.Category)
            .HasForeignKey(cc => cc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}