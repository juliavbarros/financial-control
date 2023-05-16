using JVB.FinancialControl.Web.Extensions;

namespace JVB.FinancialControl.Web.Configurations
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(configuration);
        }
    }
}
