using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }

        public virtual ICollection<RecipeRating> RecipesRatings { get; private set; }
        public virtual ICollection<Recipe> Recipes { get; private set; }

        private User() { }

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

        public static User Create(Guid id, string email, string firstName, string lastName, string password)
            => new User(id, email, firstName, lastName, password);
    }
}
