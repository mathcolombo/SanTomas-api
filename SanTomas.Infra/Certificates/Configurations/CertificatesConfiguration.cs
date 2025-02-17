using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanTomas.Domain.Certificates.Entities;

namespace SanTomas.Infra.Certificates.Configurations;

public class CertificatesConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.ToTable("Certificates");
        builder.ToTable(c => c.HasComment("Tabela que armazena os certificados dos cursos"));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador único do certificado");
        
        builder.HasOne(c => c.CourseUser)
            .WithOne(cu => cu.Certificate)
            .HasForeignKey<Certificate>(c => c.CourseUserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(c => c.CourseUserId)
            .IsRequired()
            .HasComment("Refêrencia ao curso do usuário ao qual o certificado pertence");
        
        builder.Property(c => c.FilePath)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("Caminho para o arquivo do certificado");
        
        builder.Property(c => c.UploadDate)
            .IsRequired();
    }
}