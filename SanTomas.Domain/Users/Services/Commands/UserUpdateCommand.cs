namespace SanTomas.Domain.Users.Services.Commands;

public class UserUpdateCommand
{
    public string FullName { get; set; }
    public string Email { get; set; }
}