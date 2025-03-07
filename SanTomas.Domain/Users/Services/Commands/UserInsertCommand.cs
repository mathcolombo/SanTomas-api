namespace SanTomas.Domain.Users.Services.Commands;

public class UserInsertCommand
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get;  set; }
}