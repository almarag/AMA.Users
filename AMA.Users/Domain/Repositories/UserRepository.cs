namespace AMA.Users.Domain.Repositories
{
    using AMA.Common.Repositories;
    using AMA.Persistence.Contexts;
    using AMA.Persistence.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : Repository<UserModel>
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
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
