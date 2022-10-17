using BusinessLogic;
using DataAcces;
using RandomNumberService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Singleton is a single instance for the lifetime of the application domain. Scoped is a single instance for the duration of the scoped request.
//dirbant su db naudojame viska scoped. Singleton laikomi nekokia praktika. 

builder.Services.AddSingleton<IDataBaseRepository, DataBaseRepository>(); //butina rasyti virs apatinio build
builder.Services.AddScoped<IStudentsService, StudentsService>(); //sitas reiskia kad visur kur reikes naudoti IStudents naudotu students service
builder.Services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
var app = builder.Build();


;
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

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
