using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using IdentityServerSql.Entities;

namespace IdentityServerSql.Managers
{
    public interface IAuthRepository
    {
        User GetUserById(string id);
        User GetUserByUsername(string username);
        bool ValidatePassword(string username, string plainTextPassword);
    }
}
