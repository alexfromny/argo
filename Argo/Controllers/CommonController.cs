using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Argo.Models;

namespace Argo.Controllers
{
    [ChildActionOnly]
    public class CommonController : Controller
    {
        public ActionResult LanguagesDropdown()
        {
            var languages = Languages;

            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            languages.Single(x => x.Culture == currentCulture).IsActive = true;

            return PartialView(languages);
        }

        private static List<Language> Languages
        {
            get
            {
                var cultures = ConfigurationManager.AppSettings["Cultures"].Split(',');
                var culturesNames = ConfigurationManager.AppSettings["CulturesNames"].Split(',');
                var result = new List<Language>();

                for (var i = 0; i < Math.Min(culturesNames.Length, cultures.Length); i++)
                {
                    result.Add(new Language { Name = culturesNames[i], Culture = cultures[i] });
                }

                return result;
            }
        }
    }
}