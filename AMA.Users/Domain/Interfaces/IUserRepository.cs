namespace AMA.Users.Domain.Interfaces
{
    using AMA.Persistence.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<ICollection<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
    }
}
