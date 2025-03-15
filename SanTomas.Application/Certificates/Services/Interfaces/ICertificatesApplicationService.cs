using SanTomas.Application.Certificates.Dtos.Requests;
using SanTomas.Application.Certificates.Dtos.Responses;

namespace SanTomas.Application.Certificates.Services.Interfaces;

public interface ICertificatesApplicationService
{
    CertificateResponse Insert(CertificateInsertRequest request);
    CertificateResponse GetById(int id);
    CertificateResponse Delete(int id);
}