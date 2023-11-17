namespace HR_Management_WebAPI.Helpers
{
    //According to: https://stackoverflow.com/questions/43358224/how-can-i-throw-an-exception-in-an-asp-net-core-webapi-controller-that-returns-a
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (ex is ApplicationException)
                {
                    await context.Response.WriteAsync(ex.Message);
                }
            }
        }
    }
}