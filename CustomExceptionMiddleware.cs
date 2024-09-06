
namespace EmployeeDetails
{
    public class CustomExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<h3>An Unexpected Error Occurred</h3 >");  
            }
        }
    }
}
