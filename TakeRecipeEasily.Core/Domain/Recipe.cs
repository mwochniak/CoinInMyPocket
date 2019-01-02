using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class Recipe : Entity
    {
        public string Name { get; }
        public string Description { get; }
        public Guid RecipeRatingId { get; }
        public Guid UserId { get; }

        public RecipeRating RecipeRating { get; }
        public User User { get; }
        public virtual ICollection<RecipeIngredient> RecipesIngredients { get; }

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
    }
}
