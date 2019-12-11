using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerSql.Data;
using IdentityServerSql.Managers;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using IdentityServerSql.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace identityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddInMemoryApiResources(DemoData.ApiResources)
                //.AddInMemoryClients(DemoData.Clients)
                //.AddInMemoryIdentityResources(DemoData.IdentityResources)
                //.AddTestUsers(DemoData.Users);
                .AddClientStore<ClientStore>()
                .AddCorsPolicyService<CorsPolicyService>()
                .AddResourceStore<ResourceStore>()
                .AddPersistedGrantStore<PersistedGrantStore>();       
                //.AddDeviceFlowStore<MyCustomDeviceFlowStore>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IAuthRepository, AuthRepository>();

            //services.AddTransient<IAuthorizationCodeStore, AuthorizationCodeStore>();
            //services.AddTransient<IRefreshTokenStore, MyCustomRefreshTokenStore>();
            //services.AddTransient<IReferenceTokenStore, MyCustomReferenceTokenStore>();
            //services.AddTransient<IUserConsentStore, MyCustomUserConsentStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
