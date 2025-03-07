namespace SanTomas.Application.Users.Dtos.Requests;

public record UserInsertRequest(string FullName, string Email, string Password);