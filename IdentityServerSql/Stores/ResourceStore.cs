using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServerSql.Data;

namespace IdentityServerSql.Stores
{
    public class ResourceStore: IResourceStore
    {
        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var res = scopeNames.Select(item => DemoData.IdentityResources.FirstOrDefault(s => s.Name == item)).Where(item => item != null);
            return Task.FromResult(res);

        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var res = scopeNames.Select(item => DemoData.ApiResources.FirstOrDefault(s => s.Name == item)).Where(item => item != null);
            return Task.FromResult(res);
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var res = DemoData.ApiResources.FirstOrDefault(s => s.Name == name);
            return Task.FromResult(res);
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var res = new Resources(DemoData.IdentityResources, DemoData.ApiResources);
            return Task.FromResult(res);
        }
    }
}
