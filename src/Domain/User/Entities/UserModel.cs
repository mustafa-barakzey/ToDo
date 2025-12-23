namespace brk.Todo.Domain.User.Entities;

public class UserModel
{
    public  string Email { get; private set; }
    public string Password { get; private set; }

    private UserModel(){}
    public static UserModel Register(string email, string password)
    {
        var user = new UserModel();
        user.Email = email;
        user.Password = password;
        return user;
    }
}
