using ActionFilterArea.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterArea.Controllers
{
    [Yonlen]
    public class OzelTarifController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query["kod"] != "a3cx")
                context.Result = RedirectToAction("Index", "Home", new { hata = "gecersiz" });
        }
    }
}
