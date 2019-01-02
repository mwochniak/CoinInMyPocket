using System;

namespace TakeRecipeEasily.Core.Domain
{
    public class IngredientCategoryIngredient
    {
        public Guid IngredientCategoryId { get; }
        public Guid IngredientId { get; }

        public IngredientCategory IngredientCategory { get; }
        public Ingredient Ingredient { get; }
    }
}
