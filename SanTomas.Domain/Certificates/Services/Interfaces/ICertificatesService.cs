using SanTomas.Domain.Certificates.Entities;

namespace SanTomas.Domain.Certificates.Services.Interfaces;

public interface ICertificatesService
{
    Certificate Insert(int courseUserId, string filePath);
    Certificate GetById(int id);
    Certificate Delete(int id);
}