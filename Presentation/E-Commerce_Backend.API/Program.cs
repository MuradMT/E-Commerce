using E_Commerce_Backend.Persistence;
using E_Commerce_Backend.Application;
using E_Commerce_Backend.Application.Exceptions;
using E_Commerce_Backend.Infrastructure;
using E_Commerce_Backend.Mapper;
using Microsoft.OpenApi.Models;

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

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCustomMapper();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1",new OpenApiInfo()
    {
        Title = "E-Commerce",
        Version = "v1",
        Description = "E-Commerce swagger client."
    });
    cfg.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "After writing 'Bearer',you can enter your token." +
                      "For instance: Bearer:{some random token}"
    });
    cfg.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


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
