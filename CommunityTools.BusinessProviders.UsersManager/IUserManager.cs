using System.Collections.Generic;
using CommunityTools.BusinessProvider.Models.Users;

namespace CommunityTools.BusinessProviders.Users
{
    public interface IUserManager
    {
        List<User> FindAll();
        User FindById(int id);
        void Add(User item);
        void Update(User item);
        void Remove(User item);
        void Delete(User item);
        User FindByUsername(string username);
        LoginResult Login(string username, string password, string authenticationType);
        bool Register(RegistrationRequest model);
        bool ChangePassword(ChangePasswordRequest model);
        void SaveToken(string username, string hash, Token data);
        void Logout(string username, string hash);
    }
}