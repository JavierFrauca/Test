namespace TEST.Middleware
{
    internal sealed class DemoMiddleware(RequestDelegate next)//ITokenService tokenService)
    {
        private readonly RequestDelegate _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers.Authorization.FirstOrDefault();
            //if (1==1)
            //{
                await _next(context);
                return;
            //}
            //else
            //{
            //    context.Response.StatusCode = 401; // Unauthorized
            //    await context.Response.WriteAsync("Token no válido");
            //}
        }
    }
}