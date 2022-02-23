using ApiDotNetCase.src.Application;
using ApiDotNetCase.src.Data;
using ApiDotNetCase.src.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services.AddScoped<IRepository, Repository>();
services.AddDbContext<WeatherForecastContext>(o =>
    o.UseSqlite("Data source=weatherforecast.db"));
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddScoped<WeatherForecastService>();
services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
{
    microsoftOptions.ClientId = configuration["App:Id"];
    microsoftOptions.ClientSecret = configuration["App:Secret"];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
