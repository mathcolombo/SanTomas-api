using SanTomas.Domain.Users.Entities;
using SanTomas.Domain.Users.Services.Commands;

namespace SanTomas.Domain.Users.Services.Interfaces;

public interface IUsersService
{
    User Instantiate(UserInsertCommand command);
    User Insert(UserInsertCommand command);
    User GetById(int id);
    User Update(int id, UserUpdateCommand command);
    User Delete(int id);
}