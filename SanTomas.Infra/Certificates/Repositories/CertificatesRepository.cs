using Microsoft.EntityFrameworkCore;
using SanTomas.Domain.Certificates.Entities;
using SanTomas.Domain.Certificates.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.Certificates.Repositories;

public class CertificatesRepository : Repository<Certificate>, ICertificatesRepository
{
    private readonly SanTomasDbContext _context;
    
    public CertificatesRepository(SanTomasDbContext context) : base(context)
    {
        _context = context;
    }

    public override Certificate? GetById(int id) => _context.Certificates
        .Include(c => c.CourseUser)
        .FirstOrDefault(c => c.Id == id);
}