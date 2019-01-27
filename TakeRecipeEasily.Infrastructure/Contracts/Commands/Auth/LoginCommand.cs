﻿namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth
{
    public class LoginCommand : ICommand
    {
        public string Email { get; }
        public string Password { get; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
