using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.MainCategories.Entities;
using SanTomas.Domain.MainCategories.Repositories.Interfaces;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.MainCategories.Repositories;

public class MainCategoriesRepository : Repository<MainCategory>, IMainCategoriesRepository
{
    public MainCategoriesRepository(DbContext context) : base(context) {}
}