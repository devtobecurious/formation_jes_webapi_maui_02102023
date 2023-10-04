namespace DecouverteDesFeatures.Extensions
{
    public class ListeFeaturesMiddleware
    {
        private readonly RequestDelegate next;

        public ListeFeaturesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            foreach (var feature in context.Features)
            {
                Console.WriteLine($"Feature {feature.Key} / {feature.Value}");
            }

            await next(context);
        }
    }


}
