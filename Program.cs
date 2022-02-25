using ApiDotNetCase.src.Application;
using ApiDotNetCase.src.Data;
using ApiDotNetCase.src.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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

//services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "Cookies";
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//})
//    .AddCookie("Cookies")
//    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
//options =>
//{
//    options.SignInScheme = "Cookies";
//    options.Authority = "https://login.microsoftonline.com/0a518b3a-b3a4-40f3-b906-dbe9d48dda38/v2.0";
//    options.RequireHttpsMetadata = false;
//    options.ClientId = configuration["App:Id"];
//    options.ClientSecret = configuration["App:Secret"];
//    options.SaveTokens = true;
//    options.Scope.Add("User.Read");
//    //options.CallbackPath = "/signin-oidc";
//});

services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.Cookie.IsEssential = true;
    })
    .AddGoogle(googleOptions =>
{
    googleOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    googleOptions.ClientId = configuration["Google:Id"];
    googleOptions.ClientSecret = configuration["Google:Secret"];
    googleOptions.CallbackPath = "/signin-google";
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
