using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.CoursesCategories.Entities;

namespace SanTomas.Infra.Courses.Configurations;

public class CoursesCategoriesConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.ToTable("CoursesCategories");
        builder.ToTable(cc => cc.HasComment("Tabela associativa que armazena as associações entre cursos e categorias"));
        
        builder.HasKey(cc => cc.Id);
        builder.Property(cc => cc.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único da relação curso e categoria");
        
        builder.HasOne(cc => cc.Course)
            .WithMany(c => c.CoursesCategories)
            .HasForeignKey(cc => cc.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(cc => cc.CourseId)
            .IsRequired()
            .HasComment("Referência a um dos cursos que a categoria está relacionada");

        builder.HasOne(cc => cc.Category)
            .WithMany(c => c.CoursesCategories)
            .HasForeignKey(cc => cc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(cc => cc.CategoryId)
            .IsRequired()
            .HasComment("Referência uma das categorias que o curso está relacionado");
    }
}