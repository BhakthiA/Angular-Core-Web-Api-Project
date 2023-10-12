using System.IdentityModel.Tokens.Jwt;

namespace JWT.Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
          _next = next;

            _logger = logFactory.CreateLogger("MyMiddleware");
        }
        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");

            if (httpContext.Request.Headers.TryGetValue("Authorization", out var val))
            {
                var token = val.ToString().Replace("Bearer ", string.Empty);
                if (token != "null")
                {
                    var readToken = new JwtSecurityTokenHandler().ReadJwtToken( token);
                    if (readToken.ValidTo < DateTime.UtcNow)
                    {
                        httpContext.Response.StatusCode = 401;
                        return;
                    }
                }
            }
            await _next(httpContext); // calling next middleware
        }
    }
}
