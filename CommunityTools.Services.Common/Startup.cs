using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace CommunityTools.Services.Common
{
    public class Startup
    {
        public static string AuthenticationType = DefaultAuthenticationTypes.ExternalBearer;
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        static Startup()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }
        public void Configuration(IAppBuilder app)
        {
            OAuthBearerOptions.AccessTokenFormat = new TicketDataFormat(app.CreateDataProtector(
                typeof(OAuthAuthorizationServerMiddleware).Namespace,
                "Access_Token", "v1"));

            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new OAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),

                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
