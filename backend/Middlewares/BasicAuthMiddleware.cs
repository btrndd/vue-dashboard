namespace backend.Middlewares;

using System.Net.Http.Headers;
using System.Text;
using backend.Interfaces;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserRepository userRepository)
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
            var email = credentials[0];
            
            context.Items["Data"] = userRepository.Login(email);
        }
        catch
        {
            // do nothing if invalid auth header
        }

        await _next(context);
    }
}