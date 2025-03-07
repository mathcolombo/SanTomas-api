using SanTomas.Domain.Users.Entities;
using SanTomas.Domain.Users.Repositories.Interfaces;
using SanTomas.Domain.Users.Services.Commands;
using SanTomas.Domain.Users.Services.Interfaces;

namespace SanTomas.Domain.Users.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public User Instantiate(UserInsertCommand command) => new User(command.FullName, command.Email, command.Password);

    public User Insert(UserInsertCommand command)
    {
        var user = Instantiate(command);
        return _usersRepository.Insert(user);
    }

    public User GetById(int id) => _usersRepository.GetById(id) ?? throw new NullReferenceException("Usuário não foi encontrado!");

    public User Update(int id, UserUpdateCommand command)
    {
        var user = GetById(id);
        Console.WriteLine(">>>>>>>>>>>" + user.FullName);
        user.SetFullName(command.FullName);
        Console.WriteLine(">>>>>>>>>>>" + user.FullName);
        user.SetEmail(command.Email);
        Console.WriteLine(">>>>>>>>>>>" + user.FullName);
        
        return _usersRepository.Update(user);
    }

    public User Delete(int id)
    {
        var user = GetById(id);
        _usersRepository.Delete(user);
        
        return user;
    }

    //public User UpdatePassword()
}