using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Utils.Repositories.Interfaces;
using SanTomas.Infra.Contexts;

namespace SanTomas.Infra.Utils.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly SanTomasDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(SanTomasDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public TEntity Insert(TEntity entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public TEntity? GetById(int id) => _dbSet.Find(id);

    public TEntity Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return entity;
    }
    
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<TEntity> Query() => _dbSet.AsQueryable();
    
}