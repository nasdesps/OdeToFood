using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            // If any component accross the application needs an IGreeter,
            // give them an instance of Greeter and use same instance throughout the application for every request.

            services.AddScoped<IRestaurantData, InMemoryRestaurant>();
            // Any component that needs IRestaurantData, create an instance for each HTTP request and reuse that instance throughout that one request,
            // then throw it away and create another instance for another request.

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IEnumerable<int> vs,
                              IGreeter greeter) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            //app.UseFileServer();  [[uses app.UseDefaultFiles();  and  app.UseStaticFiles();]]

            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            async Task handler(HttpContext context)
            {
                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            }
            app.Run(handler);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");  //=Home and =Index are for creating default, i.e going to the home page of the website. 
                                                            //System automatically adds Controller suffix.
                                                            // ? is optional
                                                            //Controller is the class name and action is the method name.

            // admin/Home/Index 
            //routeBuilder.MapRoute("Default", 
            //    "admin/{controller}/{action}");
        }
    }
}
