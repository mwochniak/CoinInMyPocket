using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    internal static class RecipesImagesCommandModelsValidation
    {
        internal static void CreateRecipeImagesCommandValidation(CreateRecipeImagesCommand command)
        {
            var result = ValitRules<CreateRecipeImagesCommand>
                .Create()
                .Ensure(c => c.RecipeId, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.UserId, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.RecipeImages, _ => _
                    .MinItems(1)
                    .MaxItems(3)
                    .Required())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest);
        }

        internal static void UpdateRecipeImagesCommandValidation(UpdateRecipeImagesCommand command)
        {
            var result = ValitRules<UpdateRecipeImagesCommand>
                .Create()
                .Ensure(c => c.RecipeId, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.UserId, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.RecipeImages, _ => _
                    .MinItems(1)
                    .MaxItems(3)
                    .Required())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest);
        }

        internal static void DeleteRecipeImagesCommandValidation(DeleteRecipeImagesCommand command)
        {
            var result = ValitRules<DeleteRecipeImagesCommand>
                .Create()
                .Ensure(c => c.Ids, _ => _
                    .MinItems(1)
                    .MaxItems(3)
                    .Required())
                .Ensure(c => c.UserId, _ => _
                    .IsNotEmpty())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest);
        }
    }
}
