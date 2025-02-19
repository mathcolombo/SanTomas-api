using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SanTomas.Infra.Utils.Repositories;

public class UnitOfWork(DbContext context)
{
    private IDbContextTransaction _transaction;

    public void BeginTransaction()
    {
        _transaction = context.Database.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            context.SaveChanges();
            _transaction?.Commit();
        }
        catch (Exception e)
        {
            _transaction?.Rollback();
            throw;
        }
        finally
        {
            _transaction?.Dispose();
        }
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}