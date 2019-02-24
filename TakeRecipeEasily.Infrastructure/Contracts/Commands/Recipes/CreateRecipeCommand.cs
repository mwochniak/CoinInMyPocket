using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class CreateRecipeCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid RecipeRatingId { get; }
        public Guid UserId { get; }
        public IEnumerable<Guid> IngredientsIds { get; }

        public CreateRecipeCommand(string name, string description, Guid userId, IEnumerable<Guid> ingredientsIds)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            RecipeRatingId = Guid.NewGuid();
            UserId = userId;
            IngredientsIds = ingredientsIds;
        }
    }
}
