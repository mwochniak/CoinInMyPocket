using System;

namespace CoinInMyPocket.Infrastructure.Contracts.QueryModels
{
    public class UserRetrieveModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
