using Microsoft.EntityFrameworkCore;
using SuiviDesWookiees.Libs;
using SuiviDesWookiees.Libs.Services.Data;
using SuiviDesWookiees.Web.API.AppCode.Extensions;
using SuiviDesWookiees.Web.API.AppCode.Loggers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WookieeDbContext>(options =>
{
    options.UseQueryTrackingBehavior(Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking);

    //options.UseInMemoryDatabase("unNomDebaseDeDonnees", optionsIM =>
    //{
    //    optionsIM.EnableNullChecks(false);
    //});

    options.UseOracle(builder.Configuration.GetConnectionString("MaClefVers"), optionsO =>
    {
        optionsO.MaxBatchSize(10);
    });
});

// Add services to the container.
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions.Add("NodeId", Environment.MachineName);
    };
});
builder.Services.AddControllers();
//.ConfigureApiBehaviorOptions(options =>
//{
//    options.SuppressInferBindingSourcesForParameters = true;
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomConsoleLoggerProvider(() =>
{
    return new CustomConsoleCOnfig(ConsoleColor.Green);
}));

builder.Services.AddSwaggerGen();

var memory = new Dictionary<string, string?>()
{
    { "hello", "Ca va ?" }
};
builder.Configuration.AddInMemoryCollection(memory);

// ne plante pas, retour null si pas trouvé
var test = builder.Configuration["test"];

var section = builder.Configuration.GetSection("Game");
builder.Services.Configure<GameSetting>(section);

builder.Services.AddBusinessServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
