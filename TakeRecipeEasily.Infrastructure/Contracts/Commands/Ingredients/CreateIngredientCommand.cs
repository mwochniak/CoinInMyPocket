using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients
{
    public class CreateIngredientCommand : Command
    {
        public Guid Id { get; }
        public Guid IngredientCategoryId { get; }
        public string Name { get; }

        public CreateIngredientCommand(Guid ingredientCategoryId, string name)
        {
            Id = Guid.NewGuid();
            IngredientCategoryId = ingredientCategoryId;
            Name = name;
        }
    }
}
