using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterArea.Attributes
{
    public class HepsiAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logger =context.HttpContext.RequestServices.GetService<ILogger<HepsiAttribute>>();
            logger!.LogInformation("********** OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<HepsiAttribute>>();
            logger!.LogInformation("********** OnActionExecuted");

        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<HepsiAttribute>>();
            logger!.LogInformation("********** OnResultExecuting");

        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<HepsiAttribute>>();
            logger!.LogInformation("********** OnResultExecuted");

        }
    }
}
