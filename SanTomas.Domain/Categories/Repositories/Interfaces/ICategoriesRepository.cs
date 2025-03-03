using SanTomas.Domain.Categories.Entities;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Domain.Categories.Repositories.Interfaces;

public interface ICategoriesRepository : IRepository<Category>
{
    Category? GetById(int id);
}