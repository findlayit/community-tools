using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.BusinessProviders.Forums;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.Services.Forums.Controllers
{
    [AllowAnonymous, RoutePrefix("threads")]
    public class ThreadController : ApiController
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IForumThreadManager _forumThreadManager;

        public ThreadController(IUnitOfWork unitofWork, IMapper mapper, IForumThreadManager forumThreadManager)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _forumThreadManager = forumThreadManager;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage FindAll()
        {
            var items = _forumThreadManager.FindAll();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage FindById(int id)
        {
            var item = _forumThreadManager.FindById(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("findbyurl/{forumUrlName}/{urlName}")]
        public HttpResponseMessage FindByUrl(string forumUrlName,string urlName)
        {
            var item = _forumThreadManager.FindByUrl(forumUrlName, urlName);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("findbyforumid/{forumId}")]
        public HttpResponseMessage FindByForumId(int forumId)
        {
            var items = _forumThreadManager.FindByForumId(forumId);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("findbyforumurl/{urlName}")]
        public HttpResponseMessage FindByForumUrl(string urlName)
        {
            var items = _forumThreadManager.FindByForumUrl(urlName);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add(ForumThread item)
        {
            _forumThreadManager.Add(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("{id}")]
        public HttpResponseMessage Edit(ForumThread item)
        {
            _forumThreadManager.Update(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}