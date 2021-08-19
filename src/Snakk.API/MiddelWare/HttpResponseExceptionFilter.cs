using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Snakk.API.MiddelWare
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10; 

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(new
                {
                    StatusCode = exception.StatusCode,
                    ErrorMessage = exception.Message
                })
                {
                    StatusCode = exception.StatusCode,
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
