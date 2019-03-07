using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    internal static class RecipesRatingsCommandModelsValidation
    {
        internal static void CreateRecipeRatingCommandValidation(CreateRecipeRatingCommand command)
        {
            var result = ValitRules<CreateRecipeRatingCommand>
                .Create()
                .Ensure(c => c.Comment, _ => _
                    .Required()
                    .MinLength(0)
                    .MaxLength(2000))
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.Rate, _ => _
                    .IsGreaterThan(0)
                    .IsLessThanOrEqualTo(10))
                .Ensure(c => c.RecipeId, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.UserId, _ => _
                    .IsNotEmpty())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }

        internal static void UpdateRecipeRatingCommandValidation(UpdateRecipeRatingCommand command)
        {
            var result = ValitRules<UpdateRecipeRatingCommand>
                .Create()
                .Ensure(c => c.Comment, _ => _
                    .Required()
                    .MinLength(0)
                    .MaxLength(2000))
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.Rate, _ => _
                    .IsGreaterThan(0)
                    .IsLessThanOrEqualTo(10))
                .Ensure(c => c.RecipeId, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.UserId, _ => _
                    .IsNotEmpty())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }

        internal static void DeleteRecipeRatingCommandValidation(DeleteRecipeRatingCommand command)
        {
            var result = ValitRules<DeleteRecipeRatingCommand>
                .Create()
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.UserId, _ => _
                    .IsNotEmpty())
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }
    }
}
