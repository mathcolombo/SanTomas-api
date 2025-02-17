using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.Courses.Entities;

namespace SanTomas.Infra.Courses.Configurations;

public class CoursesConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.ToTable(c => c.HasComment("Tabela que armazena os cursos e suas informações"));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único do curso");

        builder.Property(c => c.CourseName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.Url)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("Url do curso no site da plataforma ou outro");
        
        builder.HasOne(c => c.Platform)
            .WithMany(p => p.Courses)
            .HasForeignKey(c => c.PlatformId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(c => c.PlatformId)
            .IsRequired()
            .HasComment("Referência à plataforma do curso");

        builder.Property(c => c.Hours)
            .IsRequired()
            .HasColumnType("decimal(6, 2")
            .HasComment("Horas totais oferecidas pelo curso");
        
        // Navigations EF
        builder.HasMany(c => c.CoursesCategories)
            .WithOne(cc => cc.Course)
            .HasForeignKey(cc => cc.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}