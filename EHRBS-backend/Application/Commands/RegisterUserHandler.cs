﻿using MediatR;
using EHRBS_backend.Persistence.Interfaces;
using EHRBS_backend.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using EHRBS_backend.Application.Commands;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Users
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = EHRBS_backend.Domain.Enums.UserRole.Doctor
        };

        await _userRepository.AddUserAsync(user);
        return true;
    }
}
