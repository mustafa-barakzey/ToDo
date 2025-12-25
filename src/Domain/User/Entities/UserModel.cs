
namespace brk.Todo.Domain.User.Entities;

public class UserModel : BaseEntity
{
    public  string Email { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }

    private UserModel(){}
    public static UserModel Register(string email, string password)
    {
        if (!email.Contains('@'))
            throw new DomainException("email is not valid");
            
        var user = new UserModel();
        user.Email = email;
        user.Password = password;
        return user;
    }

    public void Update(string name, string family)
    {
        Name = name;
        Family = family;
    }
}
