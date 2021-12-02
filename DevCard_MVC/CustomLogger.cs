using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DevCard_MVC {
    public class CustomLogger {
        private readonly RequestDelegate _next;

        public CustomLogger(RequestDelegate next) {
            _next = next;
        }

        public Task Invoke(HttpContext context){
            //some logic here
            var title=context.Request.Query["title"];
            return _next(context);
        }
    }
    public static class CustomLoggerExtension {
        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder applicationBuilder){
            return applicationBuilder.UseMiddleware<CustomLogger>();
        }
    }
}
