namespace Arsenal2025API.Helpers;

public static class ErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}