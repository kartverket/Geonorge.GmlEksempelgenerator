using System.Web.Configuration;
using System.Web.Mvc;

namespace Kartverket.GmlSampleGenerator.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string ApplicationVersionNumber(this HtmlHelper helper)
        {
            var versionNumber = WebConfigurationManager.AppSettings["BuildVersionNumber"];
            return versionNumber;
        }

        public static string GeonorgeUrl(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["GeonorgeUrl"];
        }

        public static string KartkatalogenUrl(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["KartkatalogenUrl"];
        }

        public static string RegistryUrl(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["RegistryUrl"];
        }

        public static string EnvironmentName(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["EnvironmentName"];
        }

        public static string PostHogApiKey(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["PostHog:ApiKey"];
        }

        public static string PostHogApiHost(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["PostHog:ApiHost"];
        }

        public static string PostHogUiHost(this HtmlHelper helper)
        {
            return WebConfigurationManager.AppSettings["PostHog:UiHost"];
        }
    }
}