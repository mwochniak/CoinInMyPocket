using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class RecipeIngredient
    {
        [ForeignKey("Recipe")]
        public Guid RecipeId { get; set; }

        [ForeignKey("Ingredient")]
        public Guid IngredientId { get; set; }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public RecipeIngredient() { }

        private RecipeIngredient(Guid recipeId, Guid ingredientId)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
        }

        public static ICollection<RecipeIngredient> Create(Guid recipeId, IEnumerable<Guid> ingredientsIds)
            => ingredientsIds.ToList().Select(i => new RecipeIngredient(recipeId, i)).ToHashSet();
    }
}
