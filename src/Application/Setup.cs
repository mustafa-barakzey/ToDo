using System.Reflection;
using brk.Todo.Application.User.Register;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace brk.Todo.Application;

public static class Setup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    { 
        var commandHandlers = GetGenericImplementationTypesOf(typeof(ICommandHandler<>))
                        .SelectMany(type=>type.GetInterfaces().Select(i=>new ServiceDescriptor(i,type,ServiceLifetime.Scoped)))
                        .ToList();

        var queryHandlers = GetGenericImplementationTypesOf(typeof(IQueryHandler<,>))
                        .SelectMany(type=>type.GetInterfaces().Select(i=>new ServiceDescriptor(i,type,ServiceLifetime.Scoped)))
                        .ToList();

        services.TryAddEnumerable(queryHandlers);
        services.TryAddEnumerable(commandHandlers);
        services.AddValidatorsFromAssemblyContaining<UserRegisterCommandValidator>();
        return services;
    }

    private static IEnumerable<Type> GetGenericImplementationTypesOf(Type type)
        => Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t =>
                            !t.IsAbstract &&
                            !t.IsInterface &&
                            t.GetInterfaces()
                             .Any(i => i.IsGenericType &&
                                        i.GetGenericTypeDefinition() == type
                            ));
}
