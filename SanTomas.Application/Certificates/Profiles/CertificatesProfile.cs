using AutoMapper;
using SanTomas.Application.Certificates.Dtos.Responses;
using SanTomas.Domain.Certificates.Entities;

namespace SanTomas.Application.Certificates.Profiles;

public class CertificatesProfile : Profile
{
    public CertificatesProfile()
    {
        CreateMap<Certificate, CertificateResponse>();
    }
}