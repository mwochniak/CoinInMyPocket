using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class User : Entity
    {
        private User(
            Guid id,
            string email,
            string firstName,
            string lastName,
            string hashedPassword)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = hashedPassword;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string HashedPassword { get; }

        public static User Create(Guid id, string email, string firstName, string lastName, string password)
            => new User(id, email, firstName, lastName, password);
    }
}
