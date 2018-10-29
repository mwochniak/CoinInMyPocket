namespace TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages
{
    internal static class AuthenticationErrorCodes
    {
        internal static string UserIsNotLoggedIn => "user_is_not_logged_in";
        internal static string TokenIsNotValid => "token_is_not_valid";
        internal static string TokenExpired => "token_expired";
    }
}
