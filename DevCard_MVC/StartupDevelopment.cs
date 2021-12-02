using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevCard_MVC {
    public class StartupDevelopment {
        public void ConfigureServices(IServiceCollection services){

        }
        public void Configure(IApplicationBuilder app){
            app.Run(async Context=> {
                await Context.Response.WriteAsync("This is Development");
            });
        }
    }
}
