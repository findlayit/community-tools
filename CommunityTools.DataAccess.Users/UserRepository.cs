using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Users;
using FlexProviders.Membership;
using FlexProviders.Roles;

namespace CommunityTools.DataAccess.Users
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly IFlexMembershipProvider<UserEntity> _membershipProvider;
        private readonly IFlexRoleProvider _roleProvider;

        public UserRepository(IUnitOfWork unitOfWork, IFlexMembershipProvider<UserEntity> membershipProvider, IFlexRoleProvider roleProvider) : base(unitOfWork)
        {
            _membershipProvider = membershipProvider;
            _roleProvider = roleProvider;
        }

        public override IEnumerable<UserEntity> FindAll()
        {
            return _unitOfWork.Set<UserEntity>()
                .Include(o => o.Roles)
                .Where(o => !o.IsDeleted)
                .OrderBy(o => o.Id);
        }

        public UserEntity FindByUsername(string username)
        {
            var user = FindAll();
            return user.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && !x.IsDeleted);
        }

        public UserEntity Register(string username, string password, string role, string firstName, string lastName)
        {
            var entity = new UserEntity
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = username
            };
            _membershipProvider.CreateAccount(entity);
            _roleProvider.AddUsersToRoles(new[] { entity.Username }, new[] { role });

            _unitOfWork.Commit();

            return entity;
        }

        public LoginResult Login(string username, string password)
        {
            var result = new LoginResult();

            if (AccountLogin(username, password))
            {
                var user = FindByUsername(username);

                if ((user != null) && (!user.IsDeleted))
                {
                    result = new LoginResult()
                    {
                        Id = user.Id,
                        UserName = user.Username,
                        Roles = user.Roles.Select(x => x.Name).ToList(),
                        IsSuccessful = true
                    };
                }

            }

            return result;
        }

        public bool AccountLogin(string username, string password)
        {
            return _membershipProvider.Login(username, password);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _membershipProvider.ChangePassword(username, oldPassword, newPassword);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}