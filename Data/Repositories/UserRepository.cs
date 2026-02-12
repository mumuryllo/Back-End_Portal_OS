using Microsoft.EntityFrameworkCore;
using PortalOS.Data.Context;
using PortalOS.Domain.Entities;
using PortalOS.Interfaces.Repositories;

namespace PortalOS.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PortalOSDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
