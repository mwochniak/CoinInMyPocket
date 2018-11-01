using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    public static class AuthCommandModelsValidation
    {
        public static void LoginCommandValidation(LoginCommand command)
        {
            var result = ValitRules<LoginCommand>
                .Create()
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
