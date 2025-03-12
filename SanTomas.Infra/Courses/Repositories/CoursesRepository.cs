using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.Courses.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.Courses.Repositories;

public class CoursesRepository : Repository<Course>, ICoursesRepository
{
    private readonly SanTomasDbContext _context;
    
    public CoursesRepository(SanTomasDbContext context) : base(context)
    {
        _context = context;
    }
    
    public override Course? GetById(int id) => _context.Courses
        .Include(c => c.Platform)
        .FirstOrDefault(c => c.Id == id);
}