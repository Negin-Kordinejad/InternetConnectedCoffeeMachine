using InternetConnectedCoffeeMachine.Application.ClientAgent.Web;
using InternetConnectedCoffeeMachine.Application.ClientAgent.Web.Weather;
using InternetConnectedCoffeeMachine.Application.Infrastracture.Common.Behaviours;
using InternetConnectedCoffeeMachine.Application.Services;
using InternetConnectedCoffeeMachine.Middlewares;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddScoped<ICoffeeService, CoffeeService>();
builder.Services.AddScoped<ICoffeeCountService, CoffeeCountService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpService, HttpService>();

builder.Services.AddScoped<IWeatherApiAgent, WeatherApiAgent>();
builder.Services.AddScoped<IWeatherApiAgent, WeatherApiAgent>();


builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(NoBrewingCoffeeDayBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(OutOfCoffeeBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(WeatherBehaviour<,>));

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
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
app.UseGlobalErrorHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Expose partial class for testing.
public partial class Program { }

