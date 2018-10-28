using System;
using System.Collections.Generic;
using System.Text;

namespace CoinInMyPocket.Core.Domain
{
    public class User : Entity
    {
        protected User(
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

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string HashedPassword { get; protected set; }

        public static User Create(Guid id, string email, string firstName, string lastName, string password)
            => new User(id, email, firstName, lastName, password);
    }
}
