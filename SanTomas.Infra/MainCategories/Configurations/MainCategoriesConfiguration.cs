using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.MainCategories.Entities;

namespace SanTomas.Infra.MainCategories.Configurations;

public class MainCategoriesConfiguration : IEntityTypeConfiguration<MainCategory>
{
    public void Configure(EntityTypeBuilder<MainCategory> builder)
    {
        builder.ToTable("MainCategories");
        builder.ToTable(mc => mc.HasComment("Tabela que armazena as categorias principais dos cursos"));
        
        builder.HasKey(mc => mc.Id);
        builder.Property(mc => mc.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único da categoria principal");

        builder.Property(mc => mc.MainCategoryName)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Nome da categoria principal (ex: TI, Concurso, Finanças, etc.)");
        builder.HasIndex(mc => mc.MainCategoryName)
            .IsUnique()
            .HasDatabaseName("IX_MainCategories_MainCategoryName");
        
        // Navigations EF
        builder.HasMany(mc => mc.Categories)
            .WithOne(c => c.MainCategory)
            .HasForeignKey(c => c.MainCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}