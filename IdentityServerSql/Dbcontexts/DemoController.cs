using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServer4;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IdentityServerSql.Dbcontexts
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public async Task<object> Post( [FromServices] IdentityServerTools tools)
        
        {
            //var model = JsonConvert.DeserializeObject<DemoModel>(data);
            var token = await tools.IssueClientJwtAsync(
                clientId: "client1",
                lifetime: 2,
                scopes: new[] {"api1", "api2","api_100000"},
                audiences: new[] {"identity","trieudk_aud"},
                additionalClaims: new List<Claim>
                {
                    new Claim(type: "trieudk_claims1", value: "trieudk_claims1"),
                    new Claim(type: "trieudk_claims2", value: "trieudk_claims2"),
                    new Claim(type: "trieudk_claims3", value: "trieudk_claims3"),
                });
            var token1 = await tools.IssueJwtAsync(
                lifetime:2,
                claims:
                new List<Claim>
                {
                    new Claim(type: "trieudk_claims1", value: "trieudk_claims1"),
                    new Claim(type: "trieudk_claims2", value: "trieudk_claims2"),
                    new Claim(type: "trieudk_claims3", value: "trieudk_claims3"),
                }, 
                issuer:"trieudk_issuer");
            return token +"---------------------------"+token1;
        }
    }

    public class DemoModel
    {
        public string ClientId { get; set; }
        public string ClientSecrect { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
        public string Role { get; set; }
        public string GrantType { get; set; }
    }
}
