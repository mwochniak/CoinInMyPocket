using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    public static class UsersCommandModelsValidation
    {
        public static void CreateUserCommandValidation(CreateUserCommand command)
        {
            var result = ValitRules<CreateUserCommand>
                .Create()
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.Email, _ => _
                    .Required()
                    .Email())
                .Ensure(c => c.Password, _ => _
                    .Required()
                    .MinLength(8))
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }
    }
}
