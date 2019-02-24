using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients
{
    public class UpdateIngredientCommand : Command
    {
        public Guid Id { get; }
        public Guid IngredientCategoryId { get; }
        public string Name { get; }

        public UpdateIngredientCommand(Guid id, Guid ingredientCategoryId, string name)
        {
            Id = id;
            IngredientCategoryId = ingredientCategoryId;
            Name = name;
        }
    }
}
