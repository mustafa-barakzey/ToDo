using brk.Todo.Application.Shared.Contracts;
using brk.Todo.Application.User.Login;
using brk.Todo.Infra.JWT;
using brk.Todo.WebApi.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace brk.Todo.WebApi.Endpoints.User;

public class UserLoginEndpoint : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapPost(ApiRoutes.Auth.Login,
            async ([FromBody]UserLoginQuery command,
                    [FromServices] IQueryHandler<UserLoginQuery,UserLoginResponse> handler,
                    [FromServices] IJwtService jwtService,
                    [FromServices] IValidator<UserLoginQuery> validator) =>
            {
                var validationResult = await validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                    return Results.BadRequest(validationResult.ToDictionary());
                var result=await handler.HandleAsync(command);
                if (result.IsSuccess && result.Data != null)
                {
                    var token = await jwtService.GenerateToken(result.Data.Id,[]);
                    return Results.Ok(QueryResponse<object>.Success(new {Token = token}));
                }
                return Results.Ok(result);
            })
            .AllowAnonymous()
            .WithName("Login user")
            .WithTags(ApiRoutes.Auth.Tag);
    }
}
