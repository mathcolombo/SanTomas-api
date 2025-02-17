using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.Users.Entities;

namespace SanTomas.Infra.Users.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.ToTable(u => u.HasComment("Tabela que armazena os usuários do sistema"));
        
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único do usuário");

        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("Nome completo do usuário");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("Endereço de e-mail do usuário");
        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_Users_Email");

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(80)
            .HasComment("Hash da senha do usuário");

        builder.Property(u => u.RegisterDate)
            .IsRequired()
            .HasComment("Data de cadastro do usuário");
        
        // Navigations EF
        builder.HasMany(u => u.CoursesUsers)
            .WithOne(cu => cu.User)
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}