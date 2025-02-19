using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Infra.Utils.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public void Create(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public TEntity? Read(int id) => _dbSet.Find(id);

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
    
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<TEntity> Query() => _dbSet.AsQueryable();
    
}