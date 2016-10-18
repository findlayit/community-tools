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
    [RoutePrefix("forumposts")]
    public class ForumPostsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> FindAll()
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments("posts")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<ForumPost>>().Result;

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
                var request = await ApiEndpoints.Forums.AppendPathSegments($"posts/{id}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<ForumPost>().Result;

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
        public async Task<HttpResponseMessage> Add(ForumPost request)
        {
            try
            {
                // Save the record away
                var postRequest = await ApiEndpoints.Forums.AppendPathSegments($"posts")
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
        [HttpGet]
        [Route("fullurl/{id}")]
        public async Task<HttpResponseMessage> FetchFullUrl(int id)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments($"posts/fullurl/{id}")
                    .GetAsync();
                var url = request.Content.ReadAsAsync<string>().Result;

                // Return the data
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(url,
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
        [Route("findbythreadurl/{forumUrlName}/{threadUrlName}")]
        public async Task<HttpResponseMessage> FindByThreadUrl(string forumUrlName, string threadUrlName)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments($"posts/findbythreadurl/{forumUrlName}/{threadUrlName}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<ForumPost>>().Result;

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