using Microsoft.AspNetCore.Authentication;
using RectangleONEHSN.Authentication;

namespace RectangleONEHSN.Configuration
{
    public static class AuthenticationConfig
    {
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        public static void UseAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
