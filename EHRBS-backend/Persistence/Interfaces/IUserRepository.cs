using System.Threading.Tasks;
using EHRBS_backend.Domain.Entities;

namespace EHRBS_backend.Persistence.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUser();
    }
}
