using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Certificates.Entities;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.MainCategories.Entities;
using SanTomas.Domain.Platforms.Entities;
using SanTomas.Domain.Users.Entities;

namespace SanTomas.Infra.Contexts;

public class SanTomasDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Course> CoursesCategories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseUser> CoursesUsers { get; set; }
    public DbSet<MainCategory> MainCategories { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<User> Users { get; set; }
    
    public SanTomasDbContext(DbContextOptions<SanTomasDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica automaticamente todas as configurações de entidade
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}