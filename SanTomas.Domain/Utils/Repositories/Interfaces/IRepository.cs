using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SanTomas.Domain.Utils.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity Insert(TEntity entity);
    TEntity? GetById(int id);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    IQueryable<TEntity> Query();
}