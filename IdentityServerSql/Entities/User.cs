using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerSql.Entities
{
    public class User:IdentityUser<string>
    {
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}
