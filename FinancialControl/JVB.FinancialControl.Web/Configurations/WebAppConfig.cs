using JVB.FinancialControl.Web.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace JVB.FinancialControl.Web.Configurations
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.AddControllersWithViews();

            //Auth
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Forbidden/";
            });

           
        }
    }
}