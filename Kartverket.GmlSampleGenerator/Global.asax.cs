using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Kartverket.GmlSampleGenerator.Models.Translations;

namespace Kartverket.GmlSampleGenerator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            ValidateReturnUrl(Context.Request.QueryString);

            var cookie = Context.Request.Cookies["_culture"];
            if (cookie == null)
            {
                cookie = new HttpCookie("_culture", Culture.NorwegianCode);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            if (!string.IsNullOrEmpty(cookie.Value))
            {
                var culture = new CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }

        void ValidateReturnUrl(NameValueCollection queryString)
        {
            if (queryString != null)
            {
                var returnUrl = queryString.Get("returnUrl");
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = returnUrl.Replace("http://", "");
                    returnUrl = returnUrl.Replace("https://", "");

                    var host = Request.Url.Host;
                    if (returnUrl.StartsWith("localhost:10269"))
                        host = "localhost";

                    if (!returnUrl.StartsWith(host))
                        HttpContext.Current.Response.StatusCode = 400;
                }
            }
        }
    }
}
