using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngularCoreDemo.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AngularCoreDemo.Models;

namespace AngularCoreDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add InMemory database
            services.AddDbContext<DbsContext>(options => options.UseInMemoryDatabase(databaseName: "ValuesDatabase"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Add some data to the database
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //var dbsContext = app.ApplicationServices.GetService<DbsContext>();
                var dbsContext = serviceScope.ServiceProvider.GetService<DbsContext>();
                AddDbsData(dbsContext);
            }

            // Redirect any non-API calls to the Angular application so our application can the routing
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            // Configure application for usage as API with default route of 'api/[Controller]'
            app.UseMvcWithDefaultRoute();

            // Configures application to serve the index.html file from /wwwroot when you access the server from a web browser
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        /// <summary>
        ///  Add some data to the database
        /// </summary>
        /// <param name="context"></param>
        private void AddDbsData(DbsContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var item = new Value
                {
                    Name = "Value " + i,
                    Description = "Description " + i
                };

                context.Values.Add(item);
            }

            context.SaveChanges();
        }
    }
}