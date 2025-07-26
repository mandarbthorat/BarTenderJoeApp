using BarTenderJoe.Application;
using BarTenderJoe.Application.DependencyInjection;
using BarTenderJoe.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bartender Joe API",
        Version = "v1",
        Description = "API for product validation and drink mixing"
    });
});
var gatewayOrigin = builder.Configuration["AllowedOrigins:Gateway"];
if (string.IsNullOrWhiteSpace(gatewayOrigin))
{
    throw new InvalidOperationException("AllowedOrigins:Gateway configuration value is missing or empty.");
}
builder.Services.AddCors(options =>
{
    options.AddPolicy("StrictAPI", policy =>
            policy.WithOrigins(gatewayOrigin)
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});


builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}
app.UseCors("StrictAPI");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
