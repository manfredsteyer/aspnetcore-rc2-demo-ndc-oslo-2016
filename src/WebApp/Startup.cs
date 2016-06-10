using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FlugDemo.Data;
using System.IdentityModel.Tokens.Jwt;

namespace WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                // XML, INI

            #region usersecrets
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
                    // dotnet user-secrets list
            }
            #endregion

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            var cnnString = Configuration["ConnectionStrings:DefaultConnection"];

            #region usersectet 2
            var verySecretPassword = Configuration["verySecretPassword"];
            #endregion

        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            }).AddXmlDataContractSerializerFormatters();/*.AddMvcOptions(options => {
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });*/
            services.AddTransient<IFlightRepository, FlightEfRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
