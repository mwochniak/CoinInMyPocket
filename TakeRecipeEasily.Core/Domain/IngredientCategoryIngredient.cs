using System;

namespace TakeRecipeEasily.Core.Domain
{
    public class IngredientCategoryIngredient
    {
        public Guid IngredientCategoryId { get; private set; }
        public Guid IngredientId { get; private set; }

        public IngredientCategory IngredientCategory { get; private set; }
        public Ingredient Ingredient { get; private set; }
    }
}
