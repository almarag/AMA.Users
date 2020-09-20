namespace AMA.Users.Domain.Interfaces
{
    using AMA.Persistence.Models;
    using System.Threading.Tasks;

    public interface IPersonRepository
    {
        Task<PersonModel> CreatePerson(PersonModel model);
    }
}
