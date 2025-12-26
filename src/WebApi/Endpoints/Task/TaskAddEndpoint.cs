using brk.Todo.Application.Task.Add;

namespace brk.Todo.WebApi.Endpoints.Task;

public class TaskAddEndpoint : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapPost(ApiRoutes.Task.Add,
            async ( [FromBody]TaskAddCommand command,
                    [FromServices] ICommandHandler<TaskAddCommand> handler,
                    [FromServices] IValidator<TaskAddCommand> validator) =>
            {
                var validationResult = await validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                    return Results.BadRequest(validationResult.ToDictionary());
                    
                var result=await handler.HandleAsync(command);
                return Results.Ok(result);
            })
            .RequireAuthorization()
            .WithName("add new task")
            .WithTags(ApiRoutes.Task.Tag);
    }
}
