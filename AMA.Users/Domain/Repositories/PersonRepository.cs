namespace AMA.Users.Domain.Repositories
{
    using AMA.Persistence.Contexts;
    using AMA.Persistence.Models;
    using AMA.Persistence.Repositories;
    using AMA.Users.Domain.Interfaces;
    using System.Threading.Tasks;

    public class PersonRepository : Repository<PersonModel>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context) { }

        public async Task<PersonModel> CreatePerson(PersonModel model)
        {
            var response = await _context.Persons.AddAsync(model);
            await _context.SaveChangesAsync();

            return response.Entity;
        }
    }
}
