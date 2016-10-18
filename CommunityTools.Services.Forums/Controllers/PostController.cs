using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.BusinessProviders.Forums;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.Services.Forums.Controllers
{
    [AllowAnonymous, RoutePrefix("posts")]
    public class PostController : ApiController
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IForumPostManager _forumPostManager;

        public PostController(IUnitOfWork unitofWork, IMapper mapper, IForumPostManager forumPostManager)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _forumPostManager = forumPostManager;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage FindAll()
        {
            var items = _forumPostManager.FindAll();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage FindById(int id)
        {
            var item = _forumPostManager.FindById(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add(ForumPost item)
        {
            _forumPostManager.Add(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("{id}")]
        public HttpResponseMessage Edit(ForumPost item)
        {
            _forumPostManager.Update(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("fullurl/{id}")]
        public HttpResponseMessage FetchFullUrl(int id)
        {
            var url = _forumPostManager.FetchFullUrl(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(url, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("findbythreadurl/{forumUrlName}/{threadUrlName}")]
        public HttpResponseMessage FindByForumUrl(string forumUrlName,string threadUrlName)
        {
            var items = _forumPostManager.FindByThreadUrl(forumUrlName, threadUrlName);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
    }
}