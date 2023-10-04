using System.Globalization;
using Tests.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("Youpi, on est passé");
    await next();
});

app.Use(async (context, next) =>
{
    var cultureValue = context.Request.Query["culture"];

    if (!string.IsNullOrEmpty(cultureValue))
    {
        var culture = new CultureInfo(cultureValue);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }

    await next();

    Console.WriteLine("Alors ??");
});

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseMiddlewares(args);

app.MapControllers();

app.Run();
