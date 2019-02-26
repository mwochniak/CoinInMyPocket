using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class UpdateRecipeCommand : AuthenticatedCommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<Guid> IngredientsIds { get; }

        public UpdateRecipeCommand(Guid id, string name, string description, IEnumerable<Guid> ingredientsIds)
        {
            Id = id;
            Name = name;
            Description = description;
            IngredientsIds = ingredientsIds;
        }
    }
}
