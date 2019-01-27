using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Events.Recipes
{
    public class RecipeCreatedEvent : IEvent
    {
        public Guid RecipeId { get; }
        public IEnumerable<Guid> IngredientsIds { get; }
        public Guid RecipeRatingId { get; }

        private RecipeCreatedEvent(Guid recipeId, IEnumerable<Guid> ingredientsIds, Guid recipeRatingId)
        {
            RecipeId = recipeId;
            IngredientsIds = ingredientsIds;
            RecipeRatingId = recipeRatingId;
        }

        public static RecipeCreatedEvent Create(Guid recipeId, IEnumerable<Guid> ingredientsIds, Guid recipeRatingId)
            => new RecipeCreatedEvent(recipeId, ingredientsIds, recipeRatingId);
    }
}
