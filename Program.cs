using NETCoreDemo.Services;
using System.Text.Json.Serialization;
using NETCoreDemo.Models;
using NETCoreDemo.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions
    .Converters.Add(new JsonStringEnumConverter()));
// FIXME: Can't use enum strings in the payload

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the services for dependency injection
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IOrderProcessingService, OrderProcessingService>();
builder.Services.AddScoped<IEmailSenderService, FakeEmailSenderService>();

builder.Services.AddSingleton<IChatGPTService, FakeChatGPTService>();
builder.Services.AddSingleton<ICounterService, RequestCounterService>();

// Change this to different lifetime and see how it works
builder.Services.AddTransient<IDemoService, DemoService>();
builder.Services.AddSingleton<ICrudService<Student, StudentDTO>, FakeCrudService<Student, StudentDTO>>();

// FIXME: Missing service registration
builder.Services.Configure<CourseSetting>(builder.Configuration.GetSection("MyCourseSettings"));
// FIXME: Missing configuration registration for IOptions<CourseSetting>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
