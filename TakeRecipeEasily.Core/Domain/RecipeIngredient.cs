using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeRecipeEasily.Core.Domain
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; private set; }
        public Guid IngredientId { get; private set; }

        public Recipe Recipe { get; private set; }
        public Ingredient Ingredient { get; private set; }

        private RecipeIngredient() { }

        private RecipeIngredient(Guid recipeId, Guid ingredientId)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
        }

        public static IEnumerable<RecipeIngredient> Create(Guid recipeId, IEnumerable<Guid> ingredientsIds)
            => ingredientsIds.ToList().Select(i => new RecipeIngredient(recipeId, i));
    }
}
