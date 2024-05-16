using IUNRWA_Model.UNRWAUsers;
using IUNRWA_Repository;
using Microsoft.AspNetCore.Identity;

namespace UNRWAHealthProgramme.Configurations
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            _ = services.AddResponseCaching();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole<int>>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false; o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = false;
                o.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
