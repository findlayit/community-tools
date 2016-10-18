using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.BusinessProviders.Forums;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.Services.Forums.Controllers
{
    [AllowAnonymous, RoutePrefix("forums")]
    public class ForumController : ApiController
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IForumManager _forumManager;
        public ForumController(IUnitOfWork unitofWork, IMapper mapper, IForumManager forumManager)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _forumManager = forumManager;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage FindAll()
        {
            var items = _forumManager.FindAll();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage FindById(int id)
        {
            var item = _forumManager.FindById(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("findbyurl/{urlName}")]
        public HttpResponseMessage FindByUrl(string urlName)
        {
            var item = _forumManager.FindByUrl(urlName);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add(Forum item)
        {
            _forumManager.Add(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("{id}")]
        public HttpResponseMessage Edit(Forum item)
        {
            _forumManager.Update(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}