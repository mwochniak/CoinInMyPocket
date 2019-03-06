using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages
{
    public class DeleteRecipeImagesCommand : AuthenticatedCommand
    {
        public IEnumerable<Guid> Ids { get; }

        public DeleteRecipeImagesCommand(IEnumerable<Guid> ids) => Ids = ids;
    }
}
