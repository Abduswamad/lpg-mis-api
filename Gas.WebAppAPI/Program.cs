using Gas.Application;
using Gas.Application.Common.Exceptions;
using Gas.Utils;
using Gas.Infrastructure;
using Gas.Utils.Settings;
using Gas.WebAppAPI.ServiceDependencies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Steeltoe.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Gas.Domain.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(x => x.First());
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GMS-API", Version = "v1", Description = "Gas Management API" });
    // To Enable authorization using Swagger (JWT)  
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Authorization header using the Bearer scheme. \r\n\r\n Enter token in the text input below.\r\n\r\nExample: \"12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});


builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddWorkerServiceSettings(builder.Configuration, builder.Environment.ContentRootPath);
//...add service settings
//builder.Services.AddWorkerServiceSettings(builder.Configuration, builder.Environment.ContentRootPath);

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["Jwt:Key"]
            ))
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = async context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = 401;
            context.Response.Headers.Append("Authorization", "You don't have access, Please Request Token");

            await context.Response.WriteAsync("You don't have access, Please Request Token");
        }
    };

});

builder.Services.AddAuthorization();

builder.Services.AddCors(option => option.AddPolicy("APIPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));


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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gas API v1");
    });
}
app.UseRouting();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.UseCors("APIPolicy");
app.Run();
