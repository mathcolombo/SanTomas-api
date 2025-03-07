using SanTomas.Domain.Users.Entities;
using SanTomas.Domain.Users.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.Users.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(SanTomasDbContext context) : base(context) { }
}