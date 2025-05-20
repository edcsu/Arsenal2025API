using System.Net.Mime;
using System.Text.Json;
using Arsenal2025API.Dtos;

namespace Arsenal2025API.Helpers;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ErrorHandlingMiddleware(RequestDelegate next, 
        ILogger<ErrorHandlingMiddleware> logger, 
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "An unhandled exception occurred");

        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        
        var errorResponse = new ErrorResponse
        {
            TraceId = context.TraceIdentifier,
            Timestamp = DateTime.UtcNow,
            Path = context.Request.Path,
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = "An error occurred while processing your request"
        };
        
        switch (ex)
        {
            case KeyNotFoundException:
                response.StatusCode = StatusCodes.Status404NotFound;
                errorResponse.StatusCode = StatusCodes.Status404NotFound;
                errorResponse.Message = "The requested resource was not found";

                break;

            case ArgumentException:
                response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Message = "Invalid request";
                errorResponse.StatusCode = StatusCodes.Status400BadRequest;
                break;

            default:
                response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }
        
        if (_env.IsDevelopment())
        {
            errorResponse.DetailedMessage = ex.ToString();
        }

        var result = JsonSerializer.Serialize(errorResponse);
        await response.WriteAsync(result);
    }
}