using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.Common;
using CommunityTools.Proxy.Common;
using Flurl;
using Flurl.Http;

namespace CommunityTools.Proxy.Controllers
{
    [RoutePrefix("forums")]
    public class ForumsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> FindAll()
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments("forums")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<Forum>>().Result;

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
                var request = await ApiEndpoints.Forums.AppendPathSegments($"forums/{id}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<Forum>().Result;

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
        [Route("findbyurl/{urlName}")]
        public async Task<HttpResponseMessage> FindByUrl(string urlName)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments($"forums/findbyurl/{urlName}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<Forum>().Result;

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
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add(Forum request)
        {
            try
            {
                // Save the record away
                var postRequest = await ApiEndpoints.Forums.AppendPathSegments($"forums")
                    .PostJsonAsync(request);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(null,
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