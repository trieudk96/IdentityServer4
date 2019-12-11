using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServerSql.Entities;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerSql.Data
{
    public class DemoData
    {
        public static List<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    //AccessTokenLifetime = 10,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowOfflineAccess = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes = {"api1", "api2.has_claims","api2.no_claims", "api3", "custom.profile", "profile","profile.full_access","profile.read_only","openid"},
                    //AlwaysIncludeUserClaimsInIdToken = true,
                    //AlwaysSendClientClaims = true,
                    ClientId = "client1",
                    ClientName = "client1",
                    ClientSecrets = { new Secret("client1".Sha256()) },
                    AllowAccessTokensViaBrowser = true,

                },
                new Client
                {
                    //AccessTokenLifetime = 10,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowOfflineAccess = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes = {"api1", "api2.has_claims","api2.no_claims", "api3", "custom.profile", "profile","profile.full_access","profile.read_only","openid"},
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    ClientId = "client2",
                    ClientName = "client2",
                    ClientSecrets = { new Secret("client2".Sha256()) },
                    AllowAccessTokensViaBrowser = true,
                    Claims =
                    {
                        new Claim("claim1","value1"),
                        new Claim("claim2","value1"),
                        new Claim("claim3","value1"),
                    }
                },
            };


        public static List<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
                new IdentityResource("name",new []{"name11111111111111111111111",}),
                new IdentityResource(
                    name: "custom.profile",
                    displayName: "Custom profile",
                    claimTypes: new[] { "name", "email", "status" })
            };
        public static List<ApiResource> ApiResources =>
             new List<ApiResource>{
                new ApiResource("api1", "Some API 1"),

                new ApiResource
                {
                    Name = "profile",

                    ApiSecrets = { new Secret("secret".Sha256()) },

                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email },

                    Scopes =
                    {
                        new Scope()
                        {
                            Name = "profile.full_access",
                            DisplayName = "Full access to API 2",
                        },
                        new Scope
                        {
                            Name = "profile.read_only",
                            DisplayName = "Read only access to API 2"
                        }
                    }
                },
                new ApiResource
                {
                    Name = "api2",
                    Scopes = new List<Scope>
                    {
                        new Scope("api2.no_claims"),
                        new Scope("api2.has_claims",new []{"email","name","openid","phone"})
                    },
                },
                 new ApiResource
                {
                    Name = "api3",
                    Scopes = new List<Scope>
                    {
                        new Scope("api3",new []{"email","name","openid","phone"}),
                    },
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email,JwtClaimTypes.Audience },
                },
             };

        public static List<TestUser> Users => new List<TestUser>
        {
            new TestUser
            {
                Username = "trieudk",
                Claims = new List<Claim>{
                    new Claim("profile","trieudk.profile.claim","string","trieudk_issuer"),
                    new Claim("full_name","full_ahihi")
                },
                IsActive = true,
                Password = "trieudk",
                ProviderName = "provider",
                SubjectId = "subject_id",
                ProviderSubjectId = "provider_subject_id"
            }
        };

        public static List<User> AppUsers =>
            new List<User>
            {
                new User
                {
                    Id = "trieudk",
                    Email = "trieudk@gmail.com",
                    UserName = "trieudk",
                    Password = "trieudk",
                    Active = true,
                    PhoneNumber = "12131232134213123"
                },
                new User
                {
                    Id = "trieudk1",
                    Email = "trieudk1@gmail.com",
                    UserName = "trieudk1",
                    Password = "trieudk",
                    Active = true,
                    PhoneNumber = "1111111"
                }
            };

        public static List<PersistedGrant> PersistedGrants { get; set; } = new List<PersistedGrant>();
    }
}
