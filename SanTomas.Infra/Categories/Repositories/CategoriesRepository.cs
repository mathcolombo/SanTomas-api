using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Categories.Repositories.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.Categories.Repositories;

public class CategoriesRepository : Repository<Category>, ICategoriesRepository
{
    public CategoriesRepository(SanTomasDbContext context) : base(context) {}
}