﻿using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    internal static class IngredientCommandModelsValidation
    {
        internal static void CreateIngredientCommandValidation(CreateIngredientCommand command)
        {
            var result = ValitRules<CreateIngredientCommand>
                .Create()
                .Ensure(c => c.Name, _ => _
                    .Required()
                    .MinLength(4)
                    .MaxLength(100))
                .Ensure(c => c.IngredientCategoryId, _ => _
                    .IsNotEmpty())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest);
        }
    }
}
