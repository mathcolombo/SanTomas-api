using SanTomas.Domain.CoursesUsers.Entities;

namespace SanTomas.Domain.Certificates.Entities;

public class Certificate
{
    public int Id { get; protected set; }
    public int CourseUserId { get; set; }
    public string FilePath { get; protected set; }
    public DateTime UploadDate { get; protected set; }
    
    // Navigations EF
    public CourseUser? CourseUser { get; protected set; }

    
    public Certificate() {}
    
    public Certificate(CourseUser courseUser,
        string filePath)
    {
        SetCorseUser(courseUser);
        SetFilePath(filePath);
        SetUploadDate();
    }

    public void SetCorseUser(CourseUser courseUser)
    {
        CourseUser = courseUser;
    }

    public void SetFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));
        if(filePath.Length > 255)
            throw new ArgumentException("Tamanho máximo de caracteres é 255");
        
        FilePath = filePath;
    }

    private void SetUploadDate() => UploadDate = DateTime.Now;
}