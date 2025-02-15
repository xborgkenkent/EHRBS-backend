using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EHRBS_backend.Persistence.Interfaces;
using EHRBS_backend.Domain.Entities;
using EHRBS_backend.Persistence.Data;

namespace EHRBS_backend.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(Users user)
        {
            Console.WriteLine("call me second");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<Users>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
