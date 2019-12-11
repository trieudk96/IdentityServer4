using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServerSql.Data;

namespace IdentityServerSql.Stores
{
    public class ClientStore: IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
           var client  =  DemoData.Clients.FirstOrDefault(s => s.ClientId == clientId);
           return Task.FromResult(client);
        }
    }
}
