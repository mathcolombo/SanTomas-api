using SanTomas.Domain.Platforms.Entities;

namespace SanTomas.Domain.Platforms.Services.Interfaces;

public interface IPlatformsService
{
    Platform Instantiate(string platformName, string url);
    Platform GetById(int id);
    Platform Insert(string platformName, string url);
    Platform Update(int id, string platformName, string url);
    Platform Delete(int id);
}