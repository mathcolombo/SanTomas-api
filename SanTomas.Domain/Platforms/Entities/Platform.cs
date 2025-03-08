using System.ComponentModel.DataAnnotations;
using SanTomas.Domain.Courses.Entities;

namespace SanTomas.Domain.Platforms.Entities;

public class Platform
{
    public int Id { get; protected set; }
    public string PlatformName { get; protected set; }
    public string Url { get; protected set; }
    
    public ICollection<Course>? Courses { get; protected set; }

    public Platform() {}
    
    public Platform(string platformName, string url)
    {
        Courses = new List<Course>();
        SetPlatformName(platformName);
        SetUrl(url);
    }

    public void SetPlatformName(string platformName)
    {
        if(string.IsNullOrWhiteSpace(platformName))
            throw new ArgumentNullException(nameof(platformName));
        if(platformName.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(platformName));
        
        PlatformName = platformName;
    }

    public void SetUrl(string url)
    {
        if(string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));
        if(url.Length > 255)
            throw new ArgumentOutOfRangeException(nameof(url));
        
        Url = url;
    }
}