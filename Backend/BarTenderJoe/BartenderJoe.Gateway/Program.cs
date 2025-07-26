using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var angularOrigin = builder.Configuration["AllowedOrigins:AngularApp"];
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        if (!string.IsNullOrWhiteSpace(angularOrigin))
        {
            policy.WithOrigins(angularOrigin)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        }
        else
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    });
});

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();
app.UseCors("CORS");
app.UseRouting();
await app.UseOcelot();

app.Run();
