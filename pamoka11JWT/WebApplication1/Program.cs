using Attempt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("Client", options => //uzsiregistravom http klienta, priskyrem jam pavadinima(weatherClient)
{
    options.BaseAddress = new Uri("https://localhost:7250");

});

builder.Services.AddHttpClient("Client7", options => //uzsiregistravom http klienta, priskyrem jam pavadinima(weatherClient)
{
    options.BaseAddress = new Uri("https://localhost:7097");

});

builder.Services.AddScoped<IHttpRepository, HttpRepository>();

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
