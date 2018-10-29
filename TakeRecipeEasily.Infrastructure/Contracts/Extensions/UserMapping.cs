using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Contracts.Extensions
{
    public static class UserMapping
    {
        public async static Task<UserRetrieveModel> AsModel(this Task<User> that)
            => (await that).AsModel();

        public static UserRetrieveModel AsModel(this User user)
            => new UserRetrieveModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
    }
}
