using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.BusinessProvider.Models.Users;
using CommunityTools.Common;
using CommunityTools.Proxy.Common;
using CommunityTools.Services.Common;
using Flurl;
using Flurl.Http;
using LoginRequest = CommunityTools.BusinessProvider.Models.Users.LoginRequest;

namespace CommunityTools.Proxy.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<HttpResponseMessage> Register([FromBody] RegistrationRequest model)
        {
            try
            {
                var register = await ApiEndpoints.Users.AppendPathSegment("users/register")
              .PostJsonAsync(model);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(true, Configuration.Formatters.JsonFormatter)
                };
            }
            catch (FlurlHttpException ex)
            {
                return CommonHttpResponse.FlurlExceptionResponse(ex, Request);
            }
            catch (Exception ex)
            {
                return CommonHttpResponse.GenericExceptionResponse(ex, Request);
            }

        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid) return CommonHttpResponse.InvalidModelStateResponse(ModelState);

            try
            {

                var login = await ApiEndpoints.Users.AppendPathSegments("users/login").PostJsonAsync(model);
                var user = login.Content.ReadAsAsync<AuthenticationModel>().Result;

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(user, Configuration.Formatters.JsonFormatter)
                };
            }
            catch (FlurlHttpException ex)
            {
                return CommonHttpResponse.FlurlExceptionResponse(ex, Request);
            }
            catch (Exception ex)
            {
                return CommonHttpResponse.GenericExceptionResponse(ex, Request);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("logout")]
        public async Task<HttpResponseMessage> Logout()
        {
            var authToken = SecurityHelper.GetAuthToken(Request);
            var req = await
                    ApiEndpoints.Users.AppendPathSegments("users/logout")
                        .WithOAuthBearerToken(authToken)
                        .PostJsonAsync(null);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(null, Configuration.Formatters.JsonFormatter)
            };
        }

        [HttpGet]
        [Route("isloggedon")]
        public async Task<HttpResponseMessage> IsLoggedOn()
        {
            try
            {
                var authToken = SecurityHelper.GetAuthToken(Request);
                var req = await ApiEndpoints.Users.AppendPathSegments("users/isloggedon")
                    .WithOAuthBearerToken(authToken)
                    .GetAsync();

                var authenticated = req.Content.ReadAsAsync<bool>().Result;

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(authenticated, Configuration.Formatters.JsonFormatter)
                };
            }
            catch (FlurlHttpException ex)
            {
                return CommonHttpResponse.FlurlExceptionResponse(ex, Request);
            }
            catch (Exception ex)
            {
                return CommonHttpResponse.GenericExceptionResponse(ex, Request);
            }
        }
    }
}