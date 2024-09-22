namespace Api;

public class ApiMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _apikey;
    public ApiMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _apikey = configuration["ApiKey"] ?? string.Empty;
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        string apikey = context.Request.Headers["ApiKey"];

        //do the checking
        if (apikey == null || apikey != _apikey)
        {
            context.Response.StatusCode = 401; 
            await context.Response.WriteAsync("Access denied!");
            return;
        }

        //pass request further if correct
        await _next(context);
    }
}
public static class ApiMiddlewareExtensions
{
    public static IApplicationBuilder UseApiRequestValidation(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiMiddleware>();
    }
}