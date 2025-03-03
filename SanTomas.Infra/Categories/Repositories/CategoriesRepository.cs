using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Categories.Repositories.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.Categories.Repositories;

public class CategoriesRepository : Repository<Category>, ICategoriesRepository
{
    private readonly SanTomasDbContext _context;
    public CategoriesRepository(SanTomasDbContext context) : base(context)
    {
        _context = context;
    }

    public override Category? GetById(int id) => _context.Categories
        .Include(c => c.MainCategory)
        .FirstOrDefault(c => c.Id == id);
}