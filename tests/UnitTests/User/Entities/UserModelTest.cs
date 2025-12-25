using brk.Todo.Domain.Shared.Exceptions;
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.UnitTests.User.Entities;

public class UserModelTest
{
    private readonly string Email = "mustafabarakzey@gmail.com";
    private readonly string Password = "MyStr0ngP@ss";
    [Fact]
    public void Register_Should_CreateUser()
    {
        // When
        var user = UserModel.Register(Email, Password);
        // Then
        Assert.Equal(Email, user.Email);
        Assert.Equal(Password, user.Password);
    }
    
    [Fact]
    public void Register_Should_Throw_EmailIsNotValid()
    {
        // Given
        var email = "mustafabarakzeygmail.com";

        // When
        var action =()=> UserModel.Register(email, Password);

        // Then
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void Update_Should_PersonalInfo()
    {
        // Given
        var name = "Mustafa";
        var family = "Barakzey";
        var user = UserModel.Register(Email,Password);

        // When
        user.Update(name,family);

        // Then
        Assert.Equal(name,user.Name);
        Assert.Equal(family,user.Family);
    }
}
