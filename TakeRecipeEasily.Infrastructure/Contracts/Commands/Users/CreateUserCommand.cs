using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Users
{
    public class CreateUserCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public CreateUserCommand(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
