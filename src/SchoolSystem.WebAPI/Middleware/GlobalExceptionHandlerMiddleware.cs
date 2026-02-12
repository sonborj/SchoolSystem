using System.Net;
using System.Text.Json;
using SchoolSystem.Application.Common.Exceptions;

namespace SchoolSystem.WebAPI.Middleware;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, response) = exception switch
        {
            ValidationException validationEx => (
                (int)HttpStatusCode.BadRequest,
                (object)new { title = "Validation Error", status = 400, errors = validationEx.Errors }
            ),
            NotFoundException => (
                (int)HttpStatusCode.NotFound,
                (object)new { title = "Not Found", status = 404, detail = exception.Message }
            ),
            _ => (
                (int)HttpStatusCode.InternalServerError,
                (object)new { title = "Server Error", status = 500, detail = "An internal server error occurred." }
            )
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));
    }
}
