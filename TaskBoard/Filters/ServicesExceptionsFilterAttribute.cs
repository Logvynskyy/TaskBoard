using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskBoard.Filters
{
    public class ServicesExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(new { 
                Error = context.Exception.Message,
                Reason = "You passed wrong data!",
                StatusCode = 400
            });

            context.ExceptionHandled = true;
        }
    }
}
