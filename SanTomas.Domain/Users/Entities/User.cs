using System.ComponentModel.DataAnnotations;
using SanTomas.Domain.Courses.Entities;
using SanTomas.Domain.CoursesUsers.Entities;

namespace SanTomas.Domain.Users.Entities;

public class User
{
    public int Id { get; protected set; }
    public string FullName { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public DateOnly RegisterDate { get; protected set; }
    
    public ICollection<CourseUser>? CoursesUsers { get; protected set; }
    
    public User() {}
    
    public User(string fullName,
        string email,
        string passwordHash)
    {
        CoursesUsers = new List<CourseUser>();
        SetFullName(fullName);
        SetEmail(email);
        SetPassword(passwordHash);
        SetRegisterDate(DateOnly.FromDateTime(DateTime.Now));
    }
    public void SetFullName(string fullName)
    {
        const int MAXIMUM_SIZE_CHARACTERES_FULLNAME = 255;
        
        if(string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentNullException(nameof(fullName));
        if(fullName.Length > 255)
            throw new ArgumentException($"Tamanho de caracteres inválido: máx = {MAXIMUM_SIZE_CHARACTERES_FULLNAME}");
        
        FullName = fullName;
    }
    
    public void SetEmail(string email)
    {
        const int MAXIMUM_SIZE_CHARACTERES_EMAIL = 255;
        
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email));
        if(email.Length > 255)
            throw new ArgumentException($"Tamanho de caracteres inválido: máx = {MAXIMUM_SIZE_CHARACTERES_EMAIL}");
        
        Email = email;
    }
    
    public void SetPassword(string passwordHash)
    {
        const int MAXIMUM_SIZE_CHARACTERES_PASSWORDHASH = 80;
        
        if(passwordHash.Length > 80)
            throw new ArgumentException($"Tamanho de caracteres inválido: máx = {MAXIMUM_SIZE_CHARACTERES_PASSWORDHASH}");
        
        Password = passwordHash;
    }
    
    public void SetRegisterDate(DateOnly registerDate)
    {
        if(registerDate <= DateOnly.MinValue)
            throw new ArgumentNullException(nameof(registerDate));
        
        RegisterDate = registerDate;
    }
}