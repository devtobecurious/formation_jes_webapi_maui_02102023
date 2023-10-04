using System.Globalization;

namespace Tests.Middlewares;
public class CultureMiddleware
{
    private readonly RequestDelegate next;

    public CultureMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var cultureValue = context.Request.Query["culture"];

        if (!string.IsNullOrEmpty(cultureValue))
        {
            var culture = new CultureInfo(cultureValue);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }

        await next(context);
    }
}

public static class ExtensionMiddlewares
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app, params object[] args)
    {
        return app.UseCultureDefinition(args);
    }

    private static IApplicationBuilder UseCultureDefinition(this IApplicationBuilder app, params object[] args)
    {
        return app.UseMiddleware<CultureMiddleware>(args);
    }
}

