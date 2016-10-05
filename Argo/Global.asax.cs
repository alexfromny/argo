using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Argo
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

        private static string[] AvailableCultures => ConfigurationManager.AppSettings["Cultures"].Split(',');

        protected void Application_BeginRequest()
        {
            var culture = "en-US";

            try
            {
                HttpContextBase currentContext = new HttpContextWrapper(HttpContext.Current);
                RouteData routeData = RouteTable.Routes.GetRouteData(currentContext);

                var routeValue = routeData?.Values["culture"].ToString();
                if (!String.IsNullOrWhiteSpace(routeValue) && AvailableCultures.Contains(routeValue))
                {
                    culture = routeValue;
                    UpdateCultureCookie(culture);
                }
                else
                {
                    var cookieValue = Request.Cookies["culture"]?.Name;

                    if (cookieValue == null)
                    {
                        UpdateCultureCookie(culture);
                    }
                }
            }
            catch
            {
                // ignored
            }

            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        private void UpdateCultureCookie(string culture)
        {
            var cookie = new HttpCookie("culture", culture);
            Response.Cookies.Add(cookie);
        }
    }
}
