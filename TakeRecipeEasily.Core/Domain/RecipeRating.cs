using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class RecipeRating : Entity
    {
        public int Rate { get; private set; }
        public Guid RecipeId { get; private set; }

        public Recipe Recipe { get; private set; }

        private RecipeRating() { }

        private RecipeRating(Guid id, int rate, Guid recipeId)
        {
            Id = id;
            Rate = rate;
            RecipeId = recipeId;
        }

        public static RecipeRating Create(Guid id, int rate, Guid recipeId)
            => new RecipeRating(id, rate, recipeId);
    }
}
