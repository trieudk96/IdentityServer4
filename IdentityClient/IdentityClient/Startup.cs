using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddAuthorization(options =>
            //{

            //    options.AddPolicy("admin", policyAdmin =>
            //    {
            //        policyAdmin.RequireClaim("role", "admin");
            //        policyAdmin.AuthenticationSchemes = new List<string> { JwtBearerDefaults.AuthenticationScheme };
            //    });
            //    options.AddPolicy("member", policyUser =>
            //    {
            //        policyUser.RequireClaim("role", "member");
            //        policyUser.AuthenticationSchemes = new List<string> { JwtBearerDefaults.AuthenticationScheme };
            //    });
            //});
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // base-address of your identityserver
                    options.Authority = "https://localhost:44392/";
                    // name of the API resource
                    options.Audience = "api1";
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy.RequireClaim("role1", "admin"));
                options.AddPolicy("member", policy => policy.RequireClaim("role1", "member"));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
