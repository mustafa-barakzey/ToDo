using brk.Todo.Domain.Task.Data;
using brk.Todo.Domain.User.Data;
using brk.Todo.Infra.Persistence.Contexts;
using brk.Todo.Infra.Persistence.Task.Data;
using brk.Todo.Infra.Persistence.User.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace brk.Todo.Infra.Persistence;

internal static class Setup
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerConnectionString = configuration["ConnectionStrings:SqlServer"];
        if(string.IsNullOrWhiteSpace(sqlServerConnectionString))
            throw new NullReferenceException("SQL Server Connection string is empty");

        // services.AddDbContext<CommandDbContext>(option =>
        // {
        //     option.UseSqlServer(sqlServerConnectionString);
        // });

        services.AddDbContext<CommandDbContext>(option =>
        {
            option.UseInMemoryDatabase("Todo_db");
        });
        return services
                .AddScoped<ITaskCommandRepository,TaskCommandRepository>()
                .AddScoped<IUserCommandRepository,UserCommandRepository>();
    }
}
