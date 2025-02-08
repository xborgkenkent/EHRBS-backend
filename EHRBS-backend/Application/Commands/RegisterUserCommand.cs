using MediatR;
namespace EHRBS_backend.Application.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
