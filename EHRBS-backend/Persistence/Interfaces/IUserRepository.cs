using System.Threading.Tasks;
using EHRBS_backend.Domain.Entities;

namespace EHRBS_backend.Persistence.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(Users user);
        Task<Users> GetUserByEmailAsync(string email);
        Task<Users> GetUserByIdAsync(Guid id);
        Task<List<Users>> GetAllUser();
    }
}
