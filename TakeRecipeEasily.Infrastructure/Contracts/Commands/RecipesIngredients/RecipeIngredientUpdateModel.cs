using System;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients
{
    public sealed class RecipeIngredientUpdateModel
    {
        public int Quantity { get; }
        public Guid IngredientId { get; }
        public Unit Unit { get; }

        public RecipeIngredientUpdateModel(int quantity, Guid ingredientId, Unit unit)
        {
            Quantity = quantity;
            IngredientId = ingredientId;
            Unit = unit;
        }
    }
}
