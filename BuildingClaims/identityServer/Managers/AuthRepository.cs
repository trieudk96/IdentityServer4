using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Data;
using IdentityServer.Entities;

namespace IdentityServer.Managers
{
    public class AuthRepository :IAuthRepository
    {
        public User GetUserById(string id)
        {
            return DemoData.AppUsers.FirstOrDefault(s => s.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return DemoData.AppUsers.FirstOrDefault(s => s.UserName == username);
        }

        public bool ValidatePassword(string username, string plainTextPassword)
        {
            return DemoData.AppUsers.Any(s => s.UserName == username && s.Password == plainTextPassword);
        }
    }
}
