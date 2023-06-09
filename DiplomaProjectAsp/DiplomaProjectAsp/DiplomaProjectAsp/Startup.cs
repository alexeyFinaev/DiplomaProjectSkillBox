﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaProjectAsp.Data;
using DiplomaProjectAsp.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaProjectAsp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ISkillProfiContext, SkillProfiContext>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseHttpsRedirection();
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
