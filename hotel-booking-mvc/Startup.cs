using hotel_booking_mvc.Extensions;
using hotel_booking_services.Implmentations;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace hotel_booking_mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor(); // configure httpcontext to be accessible in other class
            services.AddHttpClient(); // configure httpclient for request to apis
            services.AddSession();


            // configures interfaces for dependency injection
            services.ConfigureDependencies(Configuration);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSession();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            
            services.AddSingleton((provider) =>
            {
                return Configuration;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LandingView}/{action=Index}/{id?}");
            });
        }
    }
}
