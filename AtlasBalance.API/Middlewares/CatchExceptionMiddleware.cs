using System.Text.Json;

using AtlasBalance.Domain.Exceptions;

namespace AtlasBalance.API.Middlewares;

public class CatchExceptionMiddleware
{
    private readonly RequestDelegate _request;

    public CatchExceptionMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext http)
    {
        try
        {
            await _request(http);
        }
        catch (Exception ex)
        {

        }
    }

    public static Task HandleExceptionAsync(HttpContext http, Exception ex)
    {
        int statusCode = ex switch
        {
            NotFoundException => 404,
            BadRequestException => 400,
            _ => 500
        };

        var response = new CatchExceptionResponse(statusCode, ex.Message);

        http.Response.ContentType = "application/json";
        http.Response.StatusCode = statusCode;
        return http.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}

internal record CatchExceptionResponse(int StatusCode, string Message);
