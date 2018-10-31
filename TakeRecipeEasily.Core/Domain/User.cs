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

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }

        public static User Create(Guid id, string email, string firstName, string lastName, string password)
            => new User(id, email, firstName, lastName, password);
    }
}
