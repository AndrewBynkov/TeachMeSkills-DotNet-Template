using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachMeSkills.BusinessLogicLayer.Managers;
using TeachMeSkills.Common.Interfaces;
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
            services.AddScoped<IAccountManger, AccountManger>();

            services.AddDbContext<TeachMeSkillsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TeachMeSkillsConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TeachMeSkillsContext>();

            services.AddControllersWithViews();
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
