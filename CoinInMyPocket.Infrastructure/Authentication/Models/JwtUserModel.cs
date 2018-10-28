using System;

namespace CoinInMyPocket.Infrastructure.Authentication.Models
{
    public class JwtUserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
