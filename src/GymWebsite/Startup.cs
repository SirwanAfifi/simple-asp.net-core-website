using System.IO;
using GymWebsite.Services.Concreates;
using GymWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace GymWebsite
{
    public class Startup
    {
        // خواندن فایل تنظیمات
        public IConfigurationRoot Configuration { set; get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // برای استفاده از تنظیمات در سراسر اپلیکیشن
            services.AddSingleton<IConfiguration>(provider => Configuration);


            services.AddTransient<IMessageService, MessageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorHandlingPath: "/HomeController/ShowError");
            }

            app.UseFileServer();

            // Serve /node_modules as a separate root (for packages that use other npm modules client side)
            app.UseFileServer(new FileServerOptions
            {
                // Set root of file server
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                // Only react to requests that match this path
                RequestPath = "/node_modules",
                // Don't expose file system
                EnableDirectoryBrowsing = false
            });

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // for SPA apps
                config.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });
        }
    }
}
