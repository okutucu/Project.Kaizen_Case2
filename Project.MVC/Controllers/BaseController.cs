using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace Project.MVC.Controllers
{
    public class BaseController : Controller
    {
       public string LANGUAGE_CODE()
        {
            return Thread.CurrentThread.CurrentCulture.Name; 
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var selectedLanguage = Request.Cookies["selectedLanguageCookie"];

            if (string.IsNullOrEmpty(selectedLanguage))
            {
                selectedLanguage = "tr-TR";
            }
            var culture = CultureInfo.CreateSpecificCulture(selectedLanguage);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

          

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
