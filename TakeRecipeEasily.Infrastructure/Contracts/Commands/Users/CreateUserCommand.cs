using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Users
{
    public class CreateUserCommand : Command
    {
        public Guid Id { get; } 
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public CreateUserCommand(string firstName, string lastName, string email, string password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
