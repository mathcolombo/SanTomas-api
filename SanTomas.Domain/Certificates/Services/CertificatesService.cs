using SanTomas.Domain.Certificates.Entities;
using SanTomas.Domain.Certificates.Repositories.Interfaces;
using SanTomas.Domain.Certificates.Services.Interfaces;
using SanTomas.Domain.CoursesUsers.Services.Interfaces;

namespace SanTomas.Domain.Certificates.Services;

public class CertificatesService : ICertificatesService
{
    private readonly ICertificatesRepository _certificatesRepository;
    private readonly ICoursesUsersService _coursesUsersService;
    
    public CertificatesService(ICertificatesRepository certificatesRepository, ICoursesUsersService coursesUsersService)
    {
        _certificatesRepository = certificatesRepository;
        _coursesUsersService = coursesUsersService;
    }

    private Certificate Instantiate(int courseUserId, string filePath)
    {
        var courseUser = _coursesUsersService.GetById(courseUserId);
        return new Certificate(courseUser, filePath);
    }
    
    public Certificate Insert(int courseUserId, string filePath)
    {
        var certificate = Instantiate(courseUserId, filePath);
        return _certificatesRepository.Insert(certificate);
    }

    public Certificate GetById(int id) => _certificatesRepository.GetById(id) ?? throw new Exception("Certificado não encontrado");
    

    public Certificate Delete(int id)
    {
        var certificate = GetById(id);
        _certificatesRepository.Delete(certificate);
        return certificate;
    }
}