using System;

namespace CommunityTools.Domain.Users
{
    public class TokenEntity
    {
        public DateTimeOffset IssuedUtc { get; set; }

        /// <summary>
        /// Value will be updated based on IssuedUtc and TokenExpiry in config
        /// </summary>
        public DateTimeOffset ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }

        public string Sid { get; set; }
    }
}