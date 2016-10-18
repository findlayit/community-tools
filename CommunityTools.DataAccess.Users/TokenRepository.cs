using System;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using CommunityTools.Domain.Users;
using Newtonsoft.Json;

namespace CommunityTools.DataAccess.Users
{
    public class TokenRepository : ITokenRepository
    {
        public TokenRepository()
        {
        }

        private readonly string _tokenExpiry = "60";

        public TokenEntity Get(string username, string hash)
        {
            var key = string.Format("{0}-{1}", username, hash);
            var cache = MemoryCache.Default;
            var cacheString =  cache[key] as string;

            return string.IsNullOrWhiteSpace(cacheString) ? JsonConvert.DeserializeObject<TokenEntity>(cacheString) : null;
        }

        public void Set(string username, string hash, TokenEntity data)
        {
            var key = string.Format("{0}-{1}", username, hash);
            var expiry = Convert.ToInt32(_tokenExpiry);
            var expiresUtc = data.IssuedUtc.Add(TimeSpan.FromMinutes(expiry));
            data.ExpiresUtc = expiresUtc;

            var cache = MemoryCache.Default;
            var cacheString = cache[key] as string;
            if (string.IsNullOrEmpty(cacheString))
            {
                cache[key] = JsonConvert.SerializeObject(data);
            }
        }

        public void Delete(string username, string hash)
        {
            var key = string.Format("{0}-{1}", username, hash);
            var cache = MemoryCache.Default;
            cache.Remove(key);
        }
    }
}