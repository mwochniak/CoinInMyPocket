using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories
{
    public class CreateIngredientCategoryCommand : Command
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateIngredientCategoryCommand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
