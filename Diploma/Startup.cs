using Antlr.Runtime.Misc;
using Diploma.DAL;
using Diploma.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Diploma
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            UserManagerFactory = () =>
            {
                var userManager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new MunicipalityContext()));

                userManager.UserValidator = new UserValidator<AppUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return userManager;
            };
        }
    }
}