using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.MainCategories.Entities;
using SanTomas.Domain.MainCategories.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.MainCategories.Repositories;

public class MainCategoriesRepository : Repository<MainCategory>, IMainCategoriesRepository
{
    public MainCategoriesRepository(SanTomasDbContext context) : base(context) {}
}