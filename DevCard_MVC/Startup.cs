using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCard_MVC {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
        }
        public void ConfigureProductionServices(IServiceCollection services) {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            //get single value from app settings
            //var applicationUrl1 = Configuration.GetValue(typeof(string), "ApplicationUrl");
            var applicationUrl = Configuration.GetValue<string>("ApplicationUrl");

            //get object from app settings
            var host = Configuration.GetSection("SiteInfo")["host"];
            var port = Configuration.GetSection("SiteInfo")["port"];
            //app.Run(async context => {
            //    await context.Response.WriteAsync("This is default");
            //});

            #region Custom MiddleWare
            //var environmentName = env.EnvironmentName;
            //if(env.IsDevelopment()) {
            //    app.UseCustomLogger();
            //}else {
            //    app.Run(async context=> {
            //        await context.Response.WriteAsync(environmentName);
            //    });
            //}
            //app.UseCustomLogger();
            #endregion

            #region  Use, Run, Map, MapWhen, UseWhen
            ////UseWhen
            //app.UseWhen(context => context.Request.Query.ContainsKey("title"), builder => {
            //    builder.Run(async context => {
            //        var branch = context.Request.Query["title"];
            //        await context.Response.WriteAsync($"this is title: {branch}");
            //    });
            //});


            ////MapWhen
            //app.MapWhen(context => context.Request.Query.ContainsKey("branch"), builder => {
            //    builder.Run(async context => {
            //        var branch = context.Request.Query["branch"];
            //        await context.Response.WriteAsync($"this is branch: {branch}");
            //    });
            //});


            ////Map
            //app.Map("/Products", appBuilder => {
            //    appBuilder.Map("/Details", builder => {
            //        builder.Run(async context => {
            //            await context.Response.WriteAsync($"this is details page");
            //        });
            //    });

            //    appBuilder.Use(async (context, next) => {
            //        var name = context.Request.Query["name"];
            //        if(!string.IsNullOrWhiteSpace(name))
            //            context.Items.Add("name", name);
            //        await next.Invoke();
            //    });
            //    appBuilder.Run(async context => {
            //        //context.Items.TryGetValue("name", out var name);
            //        var name = context.Items["name"];
            //        await context.Response.WriteAsync($"my name is : {name}");
            //    });
            //});


            ////Use
            //app.Use(async (context, next) => {
            //    context.Items.Add("name", "hossein");
            //    await next.Invoke();
            //});
            //app.Use(async (context, next) => {
            //    var id = context.Request.Query["id"];
            //    await next.Invoke();
            //    //await context.Response.WriteAsync("this is a use middleware");
            //});

            ////Run
            //app.Run(async context => {
            //    //context.Items.TryGetValue("name", out var name);
            //    var name = context.Items["name"];
            //    await context.Response.WriteAsync("Run Executed Successfully");
            //});
            #endregion

            #region Default MiddleWares
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
        }
        //public void ConfigureProduction(IApplicationBuilder app) {
        //    app.Run(async context => {
        //        await context.Response.WriteAsync("This Run Is In Production");
        //    });
        //}
        //public void ConfigureDevelopment(IApplicationBuilder app) {
        //    app.UseCustomLogger();
        //}
        //public void ConfigureStaging(IApplicationBuilder app) {
        //    app.Run(async context => {
        //        await context.Response.WriteAsync("This Run is in Staging");
        //    });
        //}
    }
}
