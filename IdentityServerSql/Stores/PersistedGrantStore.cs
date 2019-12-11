using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServerSql.Data;

namespace IdentityServerSql.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        public Task StoreAsync(PersistedGrant grant)
        {
            DemoData.PersistedGrants.Add(grant);
            return Task.FromResult(0);
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            var res = DemoData.PersistedGrants.FirstOrDefault(s => s.Key == key);
            return Task.FromResult(res);
        }

        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            return Task.FromResult(DemoData.PersistedGrants as IEnumerable<PersistedGrant>);
        }

        public Task RemoveAsync(string key)
        {
            var item = DemoData.PersistedGrants.FirstOrDefault(s => s.Key == key);
            if (item == null) return Task.FromResult(1);
            DemoData.PersistedGrants.Remove(item);
            return Task.FromResult(0);
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            DemoData.PersistedGrants = DemoData.PersistedGrants.Where(s => s.SubjectId != subjectId && s.ClientId != clientId).ToList();
            return Task.FromResult(0);
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            DemoData.PersistedGrants = DemoData.PersistedGrants.Where(s => s.SubjectId != subjectId && s.ClientId != clientId && s.Type != type).ToList();
            return Task.FromResult(0);
        }
    }
}
