using System.Net;
using System.Web.Http.Filters;

namespace TaskBoard.Filters
{
    public class ServicesExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Exception e)
            {
                context.Response = new HttpResponseMessage
                {
                    Content = new StringContent(e.Message),
                    ReasonPhrase = "You passed invalid data!",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }
    }
}
