var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//pirmas input ar output formateris skaitos default
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; //prideta per kursus. Negrazina datos tokiu formatu, kokiu klientas nepageidavo nes tiketina jam tokios nereikes
}).AddXmlDataContractSerializerFormatters(); //prideda xml input ir output formaters musu api
    ;
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

app.UseRouting(); //prideta is pamokos
app.UseAuthorization();

app.UseEndpoints(endpoints => //prideta is pamokos
{
    endpoints.MapControllers();
});

app.Run();
