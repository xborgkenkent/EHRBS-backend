using EHRBS_backend.Application.DTO;
using EHRBS_backend.Persistence.Data;
using EHRBS_backend.Persistence.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EHRBS_backend.Application.Queries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserResponse>>
    {
        private readonly AppDbContext _context;

        public GetAllUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.Select(u => new UserResponse
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
            }).ToListAsync();
        }
    }
}
