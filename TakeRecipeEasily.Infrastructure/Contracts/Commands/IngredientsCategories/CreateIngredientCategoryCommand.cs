using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories
{
    public class CreateIngredientCategoryCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
