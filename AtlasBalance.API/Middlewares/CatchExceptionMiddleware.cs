using System.Text.Json;

using AtlasBalance.Domain.Exceptions;

namespace AtlasBalance.API.Middlewares;

public class CatchExceptionMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<CatchExceptionMiddleware> _logger;

    public CatchExceptionMiddleware(RequestDelegate request, ILogger<CatchExceptionMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext http)
    {
        try
        {
            await _request(http);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error ocurred: {Message}", ex.Message);
            _logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);

            await HandleExceptionAsync(http, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext http, Exception ex)
    {
        int statusCode = ex switch
        {
            BadRequestException => 400,
            ForbiddenException => 403,
            NotFoundException => 404,
            _ => 500
        };

        var response = new CatchExceptionResponse(statusCode, ex.Message);

        http.Response.ContentType = "application/json";
        http.Response.StatusCode = statusCode;
        return http.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}

internal record CatchExceptionResponse(int StatusCode, string Message);
