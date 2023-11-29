using AccomodationApi.Data;
using AccomodationApi.Service.Interfaces;
using AccomodationApi.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = string.Empty;
builder.Services.AddControllers();
builder.Services.AddScoped<IGetPropertyName, GetPropertyNameService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var userSecret = builder.Configuration.GetSection("ConnectionStrings");
if (builder.Environment.IsDevelopment())
{
    ////builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = userSecret.GetChildren().FirstOrDefault()?.Value;
    ///connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
