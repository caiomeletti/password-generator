using AutoMapper;
using Microsoft.OpenApi.Models;
using PwdGen.API.Utilities;
using PwdGen.Services.Interfaces;
using PwdGen.Services.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPasswordService, PasswordService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Password Generator",
        Version = "v1",
        Description = "",
        Contact = new OpenApiContact()
        {
            Name = "Caio R. Meletti",
            Email = "meletti@gmail.com",
            Url = new Uri("https://github.com/caiomeletti/")

        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

IMapper mapper = ConfigMapper.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();
        
