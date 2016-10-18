using System;

namespace CommunityTools.BusinessProvider.Models.Users
{
    public class Token
    {
        public DateTimeOffset IssuedUtc { get; set; }
        public string ProtectedTicket { get; set; }
        public string Sid { get; set; }

    }
}