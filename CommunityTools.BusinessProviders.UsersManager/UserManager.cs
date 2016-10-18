using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;
using CommunityTools.DataAccess.Users;
using CommunityTools.Domain.Users;
using LoginResult = CommunityTools.BusinessProvider.Models.Users.LoginResult;
using RegistrationRequest = CommunityTools.BusinessProvider.Models.Users.RegistrationRequest;

namespace CommunityTools.BusinessProviders.Users
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenRepository _refreshTokenRepository;

        public UserManager(IMapper mapper, IUserRepository userRepository, IRoleRepository roleRepository, ITokenRepository refreshTokenRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public List<User> FindAll()
        {
            return _mapper.Map<List<User>>(_userRepository.FindAll());
        }

        public User FindById(int id)
        {
            return _mapper.Map<User>(_userRepository.FindById(id));
        }

        public void Add(User item)
        {
            var entity = _mapper.Map<Domain.Users.UserEntity>(item);
            _userRepository.Add(entity);
        }

        public void Update(User item)
        {
            var entity = _mapper.Map<Domain.Users.UserEntity>(item);
            _userRepository.Update(entity);
        }

        public void Remove(User item)
        {
            var entity = _mapper.Map<Domain.Users.UserEntity>(item);
            _userRepository.Remove(entity);
        }

        public void Delete(User item)
        {
            var entity = _mapper.Map<Domain.Users.UserEntity>(item);
            _userRepository.Delete(entity);
        }


        public User FindByUsername(string username)
        {
            return _mapper.Map<User>(_userRepository.FindByUsername(username));
        }

        public LoginResult Login(string username, string password, string authenticationType)
        {
            var loginResult = _mapper.Map<LoginResult>(_userRepository.Login(username, password));

            if (loginResult.IsSuccessful)
            {
                var guid = Guid.NewGuid();
                var identity = new ClaimsIdentity(authenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
                identity.AddClaim(new Claim(ClaimTypes.Sid, guid.ToString()));

                loginResult.Roles.ForEach(x => identity.AddClaim(new Claim(ClaimTypes.Role, x.ToLower())));

                loginResult.Identity = identity;

                return loginResult;
            }

            return null;
        }

        public bool Register(RegistrationRequest model)
        {
            var role = _roleRepository.FindAll().FirstOrDefault(o => o.Name.ToLower() == model.RoleName.ToLower());
            if (role != null)
            {
                var user = _userRepository.Register(model.UserName, model.Password, role.Name, model.FirstName,
                    model.LastName);
                return true;
            }

            return false;
        }

        public bool ChangePassword(ChangePasswordRequest model)
        {
            if (_userRepository.AccountLogin(model.UserName, model.OldPassword))
            {
                if (model.NewPassword.Equals(model.ConfirmPassword))
                    return _userRepository.ChangePassword(model.UserName, model.OldPassword, model.NewPassword);
            }
            return false;
        }

        public void SaveToken(string username, string hash, Token data)
        {
            _refreshTokenRepository.Set(username, hash, _mapper.Map<TokenEntity>(data));
        }

        public void Logout(string username, string hash)
        {
            _refreshTokenRepository.Delete(username, hash);
        }

    }
}