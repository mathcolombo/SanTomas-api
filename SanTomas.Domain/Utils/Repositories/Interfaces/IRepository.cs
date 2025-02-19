namespace SanTomas.Domain.Utils.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    void Create(TEntity entity);
    TEntity? Read(int id);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    IQueryable<TEntity> Query();
}