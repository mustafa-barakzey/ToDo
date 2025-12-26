using brk.Todo.Domain.User.Data;

namespace brk.Todo.Application.User.Login;

public class UserLoginQueryHandler(IUserQueryRepository userQueryRepository) : IQueryHandler<UserLoginQuery,UserLoginResponse>
{
    public async Task<QueryResponse<UserLoginResponse>> HandleAsync(UserLoginQuery command)
    {
        var user = await userQueryRepository.GetByEmailAndPasswordAsync(command.Email,command.Password);
        if(user is null)
            return QueryResponse<UserLoginResponse>.Faild("Email or password is wrong.");

        var output=new UserLoginResponse
        {
            Id = user.Id
        };
        return QueryResponse<UserLoginResponse>.Success(output);
    }
}
