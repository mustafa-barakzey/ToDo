using System;

namespace brk.Todo.Application.User.Login;

public class UserLoginQuery: IQuery<UserLoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserLoginResponse
{
    public int Id { get; set; }
}