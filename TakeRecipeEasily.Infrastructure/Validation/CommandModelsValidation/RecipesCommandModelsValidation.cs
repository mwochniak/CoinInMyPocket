using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    internal static class RecipesCommandModelsValidation
    {
        internal static void CreateRecipeCommandValidation(CreateRecipeCommand command)
        {
            var result = ValitRules<CreateRecipeCommand>
                .Create()
                .Ensure(c => c.Name, _ => _
                    .Required()
                    .MinLength(4)
                    .MaxLength(100))
                .Ensure(c => c.Description, _ => _
                    .Required()
                    .MinLength(4)
                    .MaxLength(1000))
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }

        internal static void UpdateRecipeCommandValidation(UpdateRecipeCommand command)
        {
            var result = ValitRules<UpdateRecipeCommand>
                .Create()
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.Name, _ => _
                    .Required()
                    .MinLength(4)
                    .MaxLength(100))
                .Ensure(c => c.Description, _ => _
                    .Required()
                    .MinLength(4)
                    .MaxLength(1000))
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }

        internal static void DeleteRecipeCommandValidation(DeleteRecipeCommand command)
        {
            var result = ValitRules<DeleteRecipeCommand>
                .Create()
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }
    }
}
