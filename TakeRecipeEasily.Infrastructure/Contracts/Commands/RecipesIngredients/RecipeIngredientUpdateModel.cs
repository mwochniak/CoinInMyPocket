using System;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients
{
    public sealed class RecipeIngredientUpdateModel
    {
        public double Quantity { get; }
        public Guid IngredientId { get; }
        public Unit Unit { get; }

        public RecipeIngredientUpdateModel(double quantity, Guid ingredientId, Unit unit)
        {
            Quantity = quantity;
            IngredientId = ingredientId;
            Unit = unit;
        }
    }
}
