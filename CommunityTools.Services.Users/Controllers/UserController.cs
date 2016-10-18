using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;
using CommunityTools.BusinessProviders.Users;
using CommunityTools.DataAccess.Common;
using CommunityTools.Services.Common;
using DotNetOpenAuth.OAuth.ChannelElements;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;

namespace CommunityTools.Services.Users.Controllers
{
    [AllowAnonymous, RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;

        public UserController(IUnitOfWork unitofWork, IMapper mapper, IUserManager userManager)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage FindAll()
        {
            var items = _userManager.FindAll();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(items, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage FindById(int id)
        {
            var item = _userManager.FindById(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(item, Configuration.Formatters.JsonFormatter)
            };
        }
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add(User item)
        {
            _userManager.Add(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("{id}")]
        public HttpResponseMessage Edit(User item)
        {
            _userManager.Update(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public HttpResponseMessage Register(RegistrationRequest request)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(request.UserName) && (_userManager.FindByUsername(request.UserName) == null))
                {
                    var isSuccessful = _userManager.Register(request);

                    var response = (isSuccessful)
                        ? Request.CreateResponse(HttpStatusCode.Created)
                        : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong.");

                    return response;
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid username.");

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public HttpResponseMessage Login(LoginRequest request)
        {
            var username = request.UserName.ToLower();
            var user = _userManager.Login(username, request.Password, Startup.AuthenticationType);
            if (user != null)
            {
                var userEntity = _userManager.FindById(user.Id);
                var identity = user.Identity;
                var currentUtc = new SystemClock().UtcNow;
                var ticket = new AuthenticationTicket(identity, new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IssuedUtc = currentUtc
                });

                var token = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

                var sid = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
                var hash = (sid != null) ? sid.Value : string.Empty;
                SaveToken(currentUtc, token, username, hash);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(new AuthenticationModel
                    {
                        UserId = user.Id,
                        UserName = username,
                        Firstname = userEntity.FirstName,
                        Lastname = userEntity.LastName,
                        Email = userEntity.Email,
                        Roles = string.Join(",", user.Roles),
                        AccessToken = token
                    }, Configuration.Formatters.JsonFormatter)
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent("Invalid username or password")
            };
        }

        [HttpPost]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                var authorizationToken = Request.Headers.Authorization.Parameter;

                if (!string.IsNullOrWhiteSpace(authorizationToken))
                {
                    var ticket = Startup.OAuthBearerOptions.AccessTokenFormat.Unprotect(authorizationToken);
                    var principal = new ClaimsPrincipal(ticket.Identity);

                    var sid = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
                    var hash = (sid != null) ? sid.Value : string.Empty;

                    _userManager.Logout(principal.Identity.Name, hash);
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("isloggedon")]
        public HttpResponseMessage IsLoggedOn()
        {
            var authToken = SecurityHelper.GetAuthToken(Request);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(HttpContext.Current.User.Identity.IsAuthenticated, Configuration.Formatters.JsonFormatter)
            };
        }

        private void SaveToken(DateTimeOffset currentUtc, string token, string username, string hash)
        {
            var refreshtoken = new Token
            {
                IssuedUtc = currentUtc,
                ProtectedTicket = token,
                Sid = hash
            };

            _userManager.SaveToken(username, hash, refreshtoken);
        }
    }
}