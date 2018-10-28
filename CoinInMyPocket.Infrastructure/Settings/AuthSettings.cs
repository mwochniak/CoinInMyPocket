using System;

namespace CoinInMyPocket.Infrastructure.Settings
{
    public class AuthSettings
    {
        public string SecretKeyBase64 { get; set; }
        public TimeSpan TokenExpiry { get; set; }

        public byte[] SecretKey => Convert.FromBase64String(SecretKeyBase64);
    }
}
