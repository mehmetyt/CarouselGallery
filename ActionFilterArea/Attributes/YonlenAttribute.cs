using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterArea.Attributes
{
    public class YonlenAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? yonlen = context.HttpContext.Request.Query["yonlen"];

            string url;

            switch (yonlen)
            {
                case "google":
                    url = "https://google.com";
                    break;
                case "yandex":
                    url = "https://yandex.com";
                    break;
                case "bing":
                    url = "https://bing.com";
                    break;
                default:
                    return;
            }
            context.Result= new RedirectResult(url);
        }
    }
}
