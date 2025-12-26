using brk.Todo.Application.Shared.Contracts;
using brk.Todo.WebApi.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace brk.Todo.WebApi.Endpoints.User;

public class UserRegisterEndpoint : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapPost(ApiRoutes.Auth.Register,
            async ([FromBody]UserRegisterCommand command,
                    [FromServices] ICommandHandler<UserRegisterCommand> handler,
                    [FromServices] IValidator<UserRegisterCommand> validator) =>
            {
                var res = await validator.ValidateAsync(command);
                if(!res.IsValid)
                    return Results.BadRequest(res.ToDictionary());

                return Results.Ok(await handler.HandleAsync(command));
            })
            .AllowAnonymous()
            .WithName("Register user")
            .WithTags(ApiRoutes.Auth.Tag);
    }
}
