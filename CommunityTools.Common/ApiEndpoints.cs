using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTools.Common
{
    public class ApiEndpoints
    {
        public static readonly string Forums = ConfigurationManager.ConnectionStrings["ForumsApiUrl"].ConnectionString;
        public static readonly string Users = ConfigurationManager.ConnectionStrings["UsersApiUrl"].ConnectionString;
    }
}
