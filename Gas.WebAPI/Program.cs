using Gas.Application;
using Gas.Application.Common.Exceptions;
using Gas.Utils;
using Gas.Infrastructure;
using Gas.Utils.Settings;
using Gas.WebAPI.ServiceDependencies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplication();

builder.Services.ConfigureUtils();

builder.Services.ConfigureInfrastructure(builder.Configuration);

builder.Services.ConfigureApiBehavior();

builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();

//builder.Services.AddDirectoryBrowser();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddWorkerServiceSettings(builder.Configuration, builder.Environment.ContentRootPath);
//...add service settings
//builder.Services.AddWorkerServiceSettings(builder.Configuration, builder.Environment.ContentRootPath);
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gas API v1");
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
