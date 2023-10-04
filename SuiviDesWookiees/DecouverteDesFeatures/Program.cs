using DecouverteDesFeatures;
using DecouverteDesFeatures.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseMiddleware<ListeFeaturesMiddleware>();


app.Use(async (context, next) =>
{
    await next(context);

    var feature = context.Features.Get<MathErrorFeature>();
    if (feature != null)
    {

    }
});

app.MapGet("/divide", (HttpContext context, double numerator, double denominator) =>
{
    if (denominator == 0)
    {
        MathErrorFeature feature = new()
        {
            Information = "Divide by zero"
        };

        context.Features.Set(feature);
        context.Features.Set(feature);

        return Results.BadRequest(feature);
    }

    return Results.Ok(numerator / denominator);
});


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
