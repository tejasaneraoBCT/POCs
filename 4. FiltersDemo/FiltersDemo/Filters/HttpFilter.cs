using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class HttpFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("HTTP Filter Executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.HttpContext.Request.IsHttps)
            {
                context.Result = new BadRequestObjectResult("Insecure Connection");
            }
        }
    }
}
