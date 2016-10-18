using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.BusinessProvider.Models.Users;
using CommunityTools.Common;
using CommunityTools.Proxy.Common;
using Flurl;
using Flurl.Http;

namespace CommunityTools.Proxy.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> FindAll()
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Users.AppendPathSegments("users")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<User>>().Result;

                // Return the data
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(entities,
                        Configuration.Formatters.JsonFormatter)
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
        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Find(int id)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Users.AppendPathSegments($"users/{id}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<User>().Result;

                // Return the data
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(entities,
                        Configuration.Formatters.JsonFormatter)
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