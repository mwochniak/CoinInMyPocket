using System;

namespace TakeRecipeEasily.Core.Domain
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; private set; }
        public Guid IngredientId { get; private set; }

        public Recipe Recipe { get; private set; }
        public Ingredient Ingredient { get; private set; }
    }
}
