namespace AMA.Users.Domain.Repositories
{
    using AMA.Persistence.Contexts;
    using AMA.Persistence.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using AMA.Persistence.Repositories;
    using AMA.Users.Domain.Interfaces;

    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<ICollection<UserModel>> GetAllUsers()
        {
            return await _context.Users
                .Include(x => x.PersonModel)
                .ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _context.Users
                .Include(x => x.PersonModel)
                .Include(x => x.UserGroups)
                .ThenInclude(x => x.GroupModel)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
