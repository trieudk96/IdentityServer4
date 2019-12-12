using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace IdentityServerSql.Managers
{
    public class CustomTokenRequestValidator: ICustomTokenRequestValidator
    {
        public Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            //context.Result.ValidatedRequest.Scopes = new[] {"trieudk_scope"};
            //context.Result.ValidatedRequest.ClientClaims = new List<Claim> {new Claim("trieudk_client_claims", "1")};
            //context.Result.ValidatedRequest.AccessTokenLifetime = 3;
            return Task.FromResult(0);
        }
    }
}
