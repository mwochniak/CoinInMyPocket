using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Users
{
    public class UserRetrieveModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
