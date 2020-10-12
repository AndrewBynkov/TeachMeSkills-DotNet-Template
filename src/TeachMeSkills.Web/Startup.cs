using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Managers;
using TeachMeSkills.BusinessLogicLayer.Repository;
using TeachMeSkills.DataAccessLayer.Contexts;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Repository pattern (Generic)
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Managers
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<ITodoManager, TodoManager>();

            // Database context
            services.AddDbContext<TeachMeSkillsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TeachMeSkillsConnection")));

            // ASP.NET Core Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TeachMeSkillsContext>();

            // Microsoft services
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); ;
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "TeachMeSkills.Cookie";
                //config.LoginPath = "/Account/SignIn";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
