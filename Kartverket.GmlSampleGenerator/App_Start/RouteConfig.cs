using System.Web.Mvc;
using System.Web.Routing;

namespace Kartverket.GmlSampleGenerator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("SignIn", "SignIn", new { controller = "Generate", action = "SignIn" });
            routes.MapRoute("SignOut", "SignOut", new { controller = "Generate", action = "SignOut" });
            // authentication - openid connect 
            routes.MapRoute("OIDC-callback-signout", "signout-callback-oidc", new { controller = "Generate", action = "SignOutCallback" });

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Generate", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}