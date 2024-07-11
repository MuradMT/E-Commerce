using E_Commerce_Backend.Persistence;
using E_Commerce_Backend.Application;
using E_Commerce_Backend.Application.Exceptions;
using E_Commerce_Backend.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env=builder.Environment;

builder.Configuration
.SetBasePath(env.ContentRootPath)
.AddJsonFile("appsettings.json",optional:false)
.AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true);



builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddCustomMapper();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.ConfiureExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
