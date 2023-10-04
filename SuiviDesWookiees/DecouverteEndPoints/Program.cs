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


app.Use(async (context, next) =>
{
    Console.WriteLine($"1. Middleware {context.GetEndpoint()?.DisplayName}");
    await next();
    Console.WriteLine("2. Middleware");
});

app.MapGet("/", (HttpContext context) =>
{
    Console.WriteLine($"3. End point : {context.GetEndpoint()?.DisplayName}");
}).WithDisplayName("DisplayBase").WithOpenApi();

app.Use(async (context, next) =>
{
    Console.WriteLine($"4. Middleware {context.GetEndpoint()?.DisplayName}");
    await next();
    Console.WriteLine("5. Middleware");
});

//app.MapWeatherForecastEndpoints();

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
