using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.Platforms.Entities;

namespace SanTomas.Infra.Platforms.Configurations;

public class PlatformsConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.ToTable("Platforms");
        builder.ToTable(p => p.HasComment("Tabela que armazena as plataformas onde os cursos são oferecidos"));
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único da plataforma");
        
        builder.Property(p => p.PlatformName)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Nome da plataforma onde o curso é oferecido (ex: Alura, Udemy, etc.)");
        builder.HasIndex(p => p.PlatformName)
            .IsUnique()
            .HasDatabaseName("IX_Platforms_PlatformName");
        
        builder.Property(p => p.Url)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("Url do site da plataforma");
        
        // Navigations EF
        builder.HasMany(p => p.Courses)
            .WithOne(c => c.Platform)
            .HasForeignKey(c => c.PlatformId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}