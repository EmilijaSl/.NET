using BusinessLogic;
using Infrastucture.HttpLayer;
using Infrastyructure.DbLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("WeatherClient",options=> //uzsiregistravom http klienta, priskyrem jam pavadinima(weatherClient)
{
    options.BaseAddress = new Uri("http://api.weatherstack.com");
    
});
builder.Services.AddDbContext<WeatherDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDb")));

builder.Services.AddScoped<IWeatherDbRepository, WeatherDbRepository>();
builder.Services.AddScoped<IWeatherHttpRepository, WeatherHttpRepository>();
builder.Services.AddScoped<IWeatherService, WeatherService>();


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
