using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class UpdateRecipeCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid RecipeRatingId { get; }
        public Guid UserId { get; }
        public IEnumerable<Guid> IngredientsIds { get; }

        public UpdateRecipeCommand(Guid id, string name, string description, Guid recipeRatingId, Guid userId, IEnumerable<Guid> ingredientsIds)
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
