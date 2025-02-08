﻿using MediatR;

public class LoginUserCommand : IRequest<AuthResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
