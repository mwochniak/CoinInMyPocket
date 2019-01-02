using System;

namespace TakeRecipeEasily.Core.Domain
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; }
        public Guid IngredientId { get; }

        public Recipe Recipe { get; }
        public Ingredient Ingredient { get; }
    }
}
