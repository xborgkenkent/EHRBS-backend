using MediatR;
using EHRBS_backend.Persistence.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using EHRBS_backend.Application.DTO;
using EHRBS_backend.Application.Queries;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);

        if (user == null)
            return null;

        Console.WriteLine("call me!!!!!!!");
        return new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email
        };
    }
}
