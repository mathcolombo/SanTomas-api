using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.CoursesUsers.Entities;
using SanTomas.Domain.CoursesUsers.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.CoursesUsers.Repositories;

public class CoursesUsersRepository : Repository<CourseUser>, ICoursesUsersRepository
{
    private readonly SanTomasDbContext _context;
    
    public CoursesUsersRepository(SanTomasDbContext context) : base(context)
    {
        _context = context;
    }

    public override CourseUser? GetById(int id) => _context.CoursesUsers
        .Include(cu => cu.Course)
        .Include(cu =>cu.User)
        .FirstOrDefault(c => c.Id == id);
}