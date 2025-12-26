using System;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace brk.Todo.WebApi.Extensions;

public static class EndpointExtension
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var enpoints= typeof(IEndpoint).Assembly.GetTypes()
                        .Where(t =>
                            !t.IsAbstract &&
                            !t.IsInterface &&
                            t.IsAssignableTo(typeof(IEndpoint)))
                        .SelectMany(type=>type.GetInterfaces().Select(i=>new ServiceDescriptor(i,type,ServiceLifetime.Scoped)))
                        .ToList();
        services.TryAddEnumerable(enpoints);
        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        using var scop = app.Services.CreateScope();
        var endpoints = scop.ServiceProvider.GetServices<IEndpoint>();
        foreach(var endpoint in endpoints)
        {
            endpoint.Map(app);
        }

        return app;
    }
}
