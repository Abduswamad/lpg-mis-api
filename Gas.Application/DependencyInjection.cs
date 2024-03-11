using System.Reflection;
using Gas.Application.Common.Behaviors;
using Gas.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Gas.Services.CompanyManagement;

namespace Gas.Application;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient<ExceptionHandlingMiddleware>();

        services.AddTransient<StaffService>();
        services.AddTransient<TruckService>();
    }
}