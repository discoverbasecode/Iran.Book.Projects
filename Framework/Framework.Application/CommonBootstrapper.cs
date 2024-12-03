using Framework.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application;

public static class CommonBootstrapper
{
    public static IServiceCollection RegisterCommonApplication(this IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

        return service;
    }
}
