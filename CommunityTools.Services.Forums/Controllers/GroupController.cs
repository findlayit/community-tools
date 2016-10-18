using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.BusinessProviders.Forums;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.Services.Forums.Controllers
{
    [AllowAnonymous, RoutePrefix("groups")]
    public class GroupController : ApiController
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IForumGroupManager _forumGroupManager;

        public GroupController(IUnitOfWork unitofWork, IMapper mapper, IForumGroupManager forumGroupManager)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _forumGroupManager = forumGroupManager;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage FindAll()
        {
            var items = _forumGroupManager.FindAll();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage FindById(int id)
        {
            var item = _forumGroupManager.FindById(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("findbyurl/{urlName}")]
        public HttpResponseMessage FindByUrl(string urlName)
        {
            var item = _forumGroupManager.FindByUrl(urlName);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add(ForumGroup item)
        {
            _forumGroupManager.Add(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("{id}")]
        public HttpResponseMessage Edit(ForumGroup item)
        {
            _forumGroupManager.Update(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}