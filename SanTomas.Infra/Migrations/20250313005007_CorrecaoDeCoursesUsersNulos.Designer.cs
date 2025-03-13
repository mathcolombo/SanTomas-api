﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SanTomas.Infra.Contexts;

#nullable disable

namespace SanTomas.Infra.Migrations
{
    [DbContext(typeof(SanTomasDbContext))]
    [Migration("20250313005007_CorrecaoDeCoursesUsersNulos")]
    partial class CorrecaoDeCoursesUsersNulos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SanTomas.Domain.Categories.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único da categoria");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nome da categoria do curso. Ex: Angular, C#, Agile, etc");

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int")
                        .HasComment("Referência à categoria principal/pai vinculada à categoria");

                    b.HasKey("Id");

                    b.HasIndex("CategoryName")
                        .IsUnique()
                        .HasDatabaseName("IX_Categories_CategoryName");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("Categories", null, t =>
                        {
                            t.HasComment("Tabela que armazena as categorias de cursos disponíveis");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.Certificates.Entities.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único do certificado");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseUserId")
                        .HasColumnType("int")
                        .HasComment("Refêrencia ao curso do usuário ao qual o certificado pertence");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasComment("Caminho para o arquivo do certificado");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CourseUserId")
                        .IsUnique();

                    b.ToTable("Certificates", null, t =>
                        {
                            t.HasComment("Tabela que armazena os certificados dos cursos");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.Courses.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único do curso");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(6, 2)")
                        .HasComment("Horas totais oferecidas pelo curso");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int")
                        .HasComment("Referência à plataforma do curso");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasComment("Url do curso no site da plataforma ou outro");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Courses", null, t =>
                        {
                            t.HasComment("Tabela que armazena os cursos e suas informações");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.CoursesCategories.Entities.CourseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único da relação curso e categoria");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Referência uma das categorias que o curso está relacionado");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasComment("Referência a um dos cursos que a categoria está relacionada");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesCategories", null, t =>
                        {
                            t.HasComment("Tabela associativa que armazena as associações entre cursos e categorias");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.CoursesUsers.Entities.CourseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único da relação curso e usuário");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data de conclusão do curso");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasComment("Referência ao curso que o usuário se matriculou");

                    b.Property<decimal?>("HoursWorked")
                        .HasColumnType("decimal(6, 2)")
                        .HasComment("Total de horas que o usuário viu o curso");

                    b.Property<decimal?>("Progress")
                        .HasColumnType("decimal(5, 2)")
                        .HasComment("Progresso do curso em porcentagem");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data de início do curso");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasComment("Status do curso -> 0 = Concluído ; 1 = Planejado ; 2 = Em andamento");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasComment("Referência o usuário que está fazendo o curso");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("CoursesUsers", null, t =>
                        {
                            t.HasComment("Tabela associativa que armazena as associações entre cursos e usuários");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.MainCategories.Entities.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único da categoria principal");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MainCategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nome da categoria principal (ex: TI, Concurso, Finanças, etc.)");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryName")
                        .IsUnique()
                        .HasDatabaseName("IX_MainCategories_MainCategoryName");

                    b.ToTable("MainCategories", null, t =>
                        {
                            t.HasComment("Tabela que armazena as categorias principais dos cursos");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.Platforms.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único da plataforma");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nome da plataforma onde o curso é oferecido (ex: Alura, Udemy, etc.)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasComment("Url do site da plataforma");

                    b.HasKey("Id");

                    b.HasIndex("PlatformName")
                        .IsUnique()
                        .HasDatabaseName("IX_Platforms_PlatformName");

                    b.ToTable("Platforms", null, t =>
                        {
                            t.HasComment("Tabela que armazena as plataformas onde os cursos são oferecidos");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.Users.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador único do usuário");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasComment("Endereço de e-mail do usuário");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasComment("Nome completo do usuário");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasComment("Hash da senha do usuário");

                    b.Property<DateOnly>("RegisterDate")
                        .HasColumnType("date")
                        .HasComment("Data de cadastro do usuário");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Users_Email");

                    b.ToTable("Users", null, t =>
                        {
                            t.HasComment("Tabela que armazena os usuários do sistema");
                        });
                });

            modelBuilder.Entity("SanTomas.Domain.Categories.Entities.Category", b =>
                {
                    b.HasOne("SanTomas.Domain.MainCategories.Entities.MainCategory", "MainCategory")
                        .WithMany("Categories")
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategory");
                });

            modelBuilder.Entity("SanTomas.Domain.Certificates.Entities.Certificate", b =>
                {
                    b.HasOne("SanTomas.Domain.CoursesUsers.Entities.CourseUser", "CourseUser")
                        .WithOne("Certificate")
                        .HasForeignKey("SanTomas.Domain.Certificates.Entities.Certificate", "CourseUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseUser");
                });

            modelBuilder.Entity("SanTomas.Domain.Courses.Entities.Course", b =>
                {
                    b.HasOne("SanTomas.Domain.Platforms.Entities.Platform", "Platform")
                        .WithMany("Courses")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("SanTomas.Domain.CoursesCategories.Entities.CourseCategory", b =>
                {
                    b.HasOne("SanTomas.Domain.Categories.Entities.Category", "Category")
                        .WithMany("CoursesCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SanTomas.Domain.Courses.Entities.Course", "Course")
                        .WithMany("CoursesCategories")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SanTomas.Domain.CoursesUsers.Entities.CourseUser", b =>
                {
                    b.HasOne("SanTomas.Domain.Courses.Entities.Course", "Course")
                        .WithMany("CoursesUsers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SanTomas.Domain.Users.Entities.User", "User")
                        .WithMany("CoursesUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SanTomas.Domain.Categories.Entities.Category", b =>
                {
                    b.Navigation("CoursesCategories");
                });

            modelBuilder.Entity("SanTomas.Domain.Courses.Entities.Course", b =>
                {
                    b.Navigation("CoursesCategories");

                    b.Navigation("CoursesUsers");
                });

            modelBuilder.Entity("SanTomas.Domain.CoursesUsers.Entities.CourseUser", b =>
                {
                    b.Navigation("Certificate");
                });

            modelBuilder.Entity("SanTomas.Domain.MainCategories.Entities.MainCategory", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("SanTomas.Domain.Platforms.Entities.Platform", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("SanTomas.Domain.Users.Entities.User", b =>
                {
                    b.Navigation("CoursesUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
