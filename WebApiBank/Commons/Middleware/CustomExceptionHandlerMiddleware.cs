using Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace WebApiBank.Commons.Middleware
{
    public class CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {

                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            switch (exception)
            {
                case CustomValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.Message);
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            if (message == string.Empty)
                message = JsonSerializer.Serialize(new { error = exception.Message });

            await context.Response.WriteAsync(message);
        }
    }
}
