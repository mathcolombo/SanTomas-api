using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.Certificates.Entities;
using SanTomas.Domain.CoursesUsers.Entities;

namespace SanTomas.Infra.Courses.Configurations;

public class CoursesUsersConfiguration : IEntityTypeConfiguration<CourseUser>
{
    public void Configure(EntityTypeBuilder<CourseUser> builder)
    {
        builder.ToTable("CoursesUsers");
        builder.ToTable(cu => cu.HasComment("Tabela associativa que armazena as associações entre cursos e usuários"));
        
        builder.HasKey(cu => cu.Id);
        builder.Property(cu => cu.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único da relação curso e usuário");

        builder.HasOne(cu => cu.Course)
            .WithMany(c => c.CoursesUsers)
            .HasForeignKey(cu => cu.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(cu => cu.CourseId)
            .IsRequired()
            .HasComment("Referência ao curso que o usuário se matriculou");
        
        builder.HasOne(cu => cu.User)
            .WithMany(u => u.CoursesUsers)
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(cu => cu.UserId)
            .IsRequired()
            .HasComment("Referência o usuário que está fazendo o curso");

        builder.Property(cu => cu.StartDate)
            .HasComment("Data de início do curso");
        
        builder.Property(cu => cu.CompletionDate)
            .HasComment("Data de conclusão do curso");

        builder.Property(cu => cu.Status)
            .IsRequired()
            .HasConversion<int>()
            .HasComment("Status do curso -> 0 = Concluído ; 1 = Planejado ; 2 = Em andamento");
        
        builder.Property(cu => cu.HoursWorked)
            .HasColumnType("decimal(6, 2)")
            .HasComment("Total de horas que o usuário viu o curso");
        
        builder.Property(cu => cu.Progress)
            .HasColumnType("decimal(5, 2)")
            .HasComment("Progresso do curso em porcentagem");

        // Navigation EF
        builder.HasOne(cu => cu.Certificate)
            .WithOne(c => c.CourseUser)
            .HasForeignKey<Certificate>(c => c.CourseUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}