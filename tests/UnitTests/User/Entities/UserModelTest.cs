using brk.Todo.Domain.Shared.Exceptions;
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.UnitTests.User.Entities;

public class UserModelTest
{
    [Fact]
    public void Register_Should_CreateUser()
    {
        // Given
        var email = "mustafabarakzey@gmail.com";
        var password = "MyStr0ngP@ss";

        // When
        var user = UserModel.Register(email, password);
        // Then
        Assert.Equal(email, user.Email);
        Assert.Equal(password, user.Password);
    }
    
    [Fact]
    public void Register_Should_Throw_EmailIsNotValid()
    {
        // Given
        var email = "mustafabarakzeygmail.com";
        var password = "MyStr0ngP@ss";

        // When
        var action =()=> UserModel.Register(email, password);
        
        // Then
        Assert.Throws<DomainException>(action);
    }
}
