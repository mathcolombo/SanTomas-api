using SanTomas.Domain.Platforms.Entities;
using SanTomas.Domain.Platforms.Repositories.Interfaces;
using SanTomas.Domain.Platforms.Services.Interfaces;

namespace SanTomas.Domain.Platforms.Services;

public class PlatformsService : IPlatformsService
{
    private readonly IPlatformsRepository _platformsRepository;

    public PlatformsService(IPlatformsRepository platformRepository)
    {
        _platformsRepository = platformRepository;
    }
    
    public Platform GetById(int id) => _platformsRepository.GetById(id) ?? throw new NullReferenceException("Plataforma não encontrada!");
    
    public Platform Instantiate(string platformName, string url) => new Platform(platformName, url);
    
    public Platform Insert(string platformName, string url)
    {
        var platform = Instantiate(platformName, url);
        return _platformsRepository.Insert(platform);
    }

    public Platform Update(int id, string platformName, string url)
    {
        var platform = GetById(id);
        
        platform.SetPlatformName(platformName);
        platform.SetUrl(url);
        
        return _platformsRepository.Update(platform);
    }

    public Platform Delete(int id)
    {
        var platform = GetById(id);
        _platformsRepository.Delete(platform);  
        return platform;
    }
}