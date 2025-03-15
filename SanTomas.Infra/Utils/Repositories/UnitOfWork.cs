using Microsoft.EntityFrameworkCore.Storage;
using SanTomas.Domain.Utils.Repositories.Interfaces;
using SanTomas.Infra.Contexts;

namespace SanTomas.Infra.Utils.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SanTomasDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(SanTomasDbContext context)
    {
        _context = context;
    }
    
    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            _context.SaveChanges();
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
        _context.SaveChanges();
    }
}