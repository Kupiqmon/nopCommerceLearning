using Autofac.Core;
using Nop.Core.Configuration;

namespace Nop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            /*
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions() {
                WebRootPath=myroot; //root (static file) folder definition   
            });

            */
            builder.Services.AddControllers(); //Automatically add class with 'Controller' as suffix

            builder.Services.AddControllers().AddXmlSerializerFormatters(); //Input Formatters

            // -- IoC Container
            /*
            builder.Services.Add(new ServiceDescriptor(

                typeof(ICitiesService),
                typeof(CitiesService),
                ServiceLifetime.Transient
            ));

            builder.Services.AddTransient<ICitiesService,CitiesService>();
            builder.Services.AddScoped<ICitiesService,CitiesService>();
            builder.Services.AddSingleton<ICitiesService,CitiesService>();

            
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddTransient<CustomMiddleware>();
            builder.Services.AddRouting(options => {
                options.ConstraintMap.Add("months", typeof(MonthConstraint));
            });*/
            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");
            // HTTP - Basics
            /*
            * app.Run(async (HttpContext context) =>
            {
                string method = context.Request.Method;
                context.Response.Headers["LearningKey"] = "myKey";
                context.Response.Headers["Content-type"] = "text/html";
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Hello World!");
                await context.Response.WriteAsync($"<p>{method}</p>");

                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();
                Dictionary<string, StringValues> queryDict =
                    Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
            });

            */

            // static file - root folder
            /* 
            app.UseStaticFiles(); // use settings when builder is created
            app.UseStaticFiles(new StaticFileOptions() {
               FileProvider = new PhysicalFileProvider(
                 Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
            });
            */



            // Middleware - Basics
            /*app.UseWhen(context => context.Request.Query.ContainsKey("username"),
                        app =>
                        {
                            app.Use(async (context, next) =>
                            {
                                await context.Response.WriteAsync("Hello from Middleware branch");
                                await next();
                            });
                        }
            );

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                // before logic
                await context.Response.WriteAsync("Hello");
                // middleware logic
                await next(context);
                // after logic
            });

            app.UseMiddleware<CustomMiddleware>();      

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("Hello");
                await next(context);
                // other code after processing the middleware
            });
            // Terminating middlewares
            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("Hello again");
            });*/

            app.Run();

        }
    }
}