using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class Recipe : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid RecipeRatingId { get; private set; }
        public Guid UserId { get; private set; }

        public RecipeRating RecipeRating { get; private set; }
        public User User { get; private set; }
        public virtual ICollection<RecipeIngredient> RecipesIngredients { get; private set; }

        private Recipe() {}

        private Recipe(Guid id, string name, string description, Guid recipeRatingId, Guid userId)
        {
            Id = id;
            Name = name;
            Description = description;
            RecipeRatingId = recipeRatingId;
            UserId = userId;
        }

        public static Recipe Create(Guid id, string name, string description, Guid recipeRatingId, Guid userId)
            => new Recipe(id, name, description, recipeRatingId, userId);

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
