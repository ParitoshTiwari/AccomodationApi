using AccomodationApi.Data;
using AccomodationApi.Service.Interfaces;
using AccomodationApi.Service.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var MyOrigins = "myOrigins";
// Add services to the container.
var connection = string.Empty;
builder.Services.AddControllers();
builder.Services.AddSingleton<ICustomLogger, CustomLogger>();
builder.Services.AddScoped<IGetPropertyName, GetPropertyNameService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Accommodation API",
        Version = "v1"
    });
});
builder.Services.AddCors(options => options.AddPolicy(name: MyOrigins, policy =>
{
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

if (builder.Environment.IsDevelopment())
{
    var userSecret = builder.Configuration.GetSection("ConnectionStrings");
    ////builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = userSecret.GetChildren().FirstOrDefault()?.Value;
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}

builder.Services.AddDbContext<PropertyContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI( c => {
        c.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; 
    }
    );
}

app.UseHttpsRedirection();

app.UseCors(MyOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
