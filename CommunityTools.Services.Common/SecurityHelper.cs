using System;
using System.Net.Http;
using System.Security;
using System.Web;

namespace CommunityTools.Services.Common
{
    public static class SecurityHelper
    {
        public static string GetAuthToken(HttpRequestMessage request)
        {
            if (request == null)
                throw new NullReferenceException("HttpRequestMessage must not be null.");

            if (request.Headers.Authorization == null)
                throw new SecurityException("Missing Authorization header for this request.");

            return request.Headers.Authorization.Parameter?.Replace("Bearer", "").Trim() ?? "";
        }

        public static string GetAuthorizationToken(this HttpRequest httpRequest)
        {
            return httpRequest.Headers["Authorization"]?.Replace("Bearer", "").Trim() ?? string.Empty;
        }
    }
}