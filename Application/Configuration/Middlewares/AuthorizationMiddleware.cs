using Application.Configuration.Utils;

namespace Application.Configuration.Middlewares
{
    public class AuthorizationMiddleware : IMiddleware
    {
        private readonly SettingsManager _settingsManager;
        public AuthorizationMiddleware(SettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Verifica o token de autorização
            if (!IsDebugMode() && !HasValidToken(context))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Request not authorized: The API key sent is invalid.");
                return;
            }

            await next(context);
        }

        // Verifica se o request tem o token de autorização
        private bool HasValidToken(HttpContext context)
        {
            string apiToken = _settingsManager.GetStringValue("ApiToken");
            string authorizationToken = context.Request.Headers["Authorization"].ToString();
            return String.Concat("Bearer ", apiToken) == authorizationToken;
        }

        private bool IsDebugMode()
        {
            return _settingsManager.GetBoolValue("DebugMode");
        }
    }
}
