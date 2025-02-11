using EHRBS_backend.Application.DTO;
using MediatR;

namespace EHRBS_backend.Application.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserResponse>>
    {
    }
}
