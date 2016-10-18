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
    [RoutePrefix("forumthreads")]
    public class ForumThreadsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> FindAll()
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments("threads")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<ForumThread>>().Result;

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
                var request = await ApiEndpoints.Forums.AppendPathSegments($"threads/{id}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<ForumThread>().Result;

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
        [Route("findbyurl/{forumUrlName}/{urlName}")]
        public async Task<HttpResponseMessage> FindByUrl(string forumUrlName,string urlName)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments($"threads/findbyurl/{forumUrlName}/{urlName}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<ForumThread>().Result;

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
        [Route("findbyforumid/{forumId}")]
        public async Task<HttpResponseMessage> FindByForumId(int forumId)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments($"threads/findbyforumid/{forumId}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<ForumThread>>().Result;

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
        [Route("findbyforumurl/{urlName}")]
        public async Task<HttpResponseMessage> FindByForumUrl(string urlName)
        {
            try
            {
                // Get list of questions for the survey.
                var request = await ApiEndpoints.Forums.AppendPathSegments($"threads/findbyforumurl/{urlName}")
                    .GetAsync();
                var entities = request.Content.ReadAsAsync<List<ForumThread>>().Result;

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
        public async Task<HttpResponseMessage> Add(ForumThread request)
        {
            try
            {
                // Save the record away
                var postRequest = await ApiEndpoints.Forums.AppendPathSegments($"threads")
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