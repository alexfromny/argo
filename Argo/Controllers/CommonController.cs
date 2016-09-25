using System.Collections.Generic;
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
            var languages = new List<Language>
            {
                new Language {Name = "ENG", Culture = "en-US"},
                new Language {Name = "RUS", Culture = "ru-RU"},
                new Language {Name = "UKR", Culture = "uk-UA"},
                new Language {Name = "PLN", Culture = "pl-PL"}
            };

            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            languages.Single(x => x.Culture == currentCulture).IsActive = true;

            return PartialView(languages);
        }
    }
}