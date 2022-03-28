using System.Net;
using System.Text.Json;
using backend.DTOs;

namespace backend.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new ResponseError
        {
            success = false
        };
        switch (exception)
        {
            case ApplicationException ex:
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                errorResponse.message = ex.Message;
                break;
            case UnauthorizedAccessException ex:
                response.StatusCode = (int) HttpStatusCode.Unauthorized;
                errorResponse.message = ex.Message;
                break;
            case KeyNotFoundException ex:
                response.StatusCode = (int) HttpStatusCode.NotFound;
                errorResponse.message = ex.Message;
                break;
            default:
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                errorResponse.message = "Internal Server errors. Check Logs!";
                break;
        }
        _logger.LogError(exception.Message);
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }
}