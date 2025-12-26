using brk.Todo.Application.Shared.Contracts;
using brk.Todo.Infra.Implementations;
using brk.Todo.Infra.JWT;
using brk.Todo.Infra.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace brk.Todo.Infra;

public static class Setup
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUser,CurrentUser>();
        services.AddPersistence(configuration);
        services.AddJwtAuthentication(configuration);
        return services;
    }
}
