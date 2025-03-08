using SanTomas.Domain.Platforms.Entities;
using SanTomas.Domain.Platforms.Repositories.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Infra.Platforms.Repositories;

public class PlatformsRepository : Repository<Platform>, IPlatformsRepository
{
    public PlatformsRepository(SanTomasDbContext context) : base(context) {}
}