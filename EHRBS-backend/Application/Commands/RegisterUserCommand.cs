﻿using MediatR;
namespace EHRBS_backend.Application.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

}
