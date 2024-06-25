﻿namespace WebApiBank.Commons.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExctensions
    {
        public static IApplicationBuilder UseCustomExceptions(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return app;
        }
    }
}
