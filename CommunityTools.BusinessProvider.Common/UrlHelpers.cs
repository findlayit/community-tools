using System.Text.RegularExpressions;

namespace CommunityTools.BusinessProvider.Common
{
    public static class UrlHelpers
    {
        public static string ConvertToUrl(string input)
        {
            var output = Regex.Replace(input, @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-").ToLower();
            return output;
        }
    }
}