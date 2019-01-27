using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class CreateRecipeCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public string Description { get; }
        public Guid RecipeRatingId { get; } = Guid.NewGuid();
        public Guid UserId { get; }
        public IEnumerable<Guid> IngredientsIds { get; }

        public CreateRecipeCommand(Guid id, string name, string description, Guid recipeRatingId, Guid userId, IEnumerable<Guid> ingredientsIds)
        {
            Id = id;
            Name = name;
            Description = description;
            RecipeRatingId = recipeRatingId;
            UserId = userId;
            IngredientsIds = ingredientsIds;
        }
    }
}
