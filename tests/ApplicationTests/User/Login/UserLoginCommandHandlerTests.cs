using brk.Todo.Application.User.Login;
using brk.Todo.Domain.User.Data;
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.ApplicationTests.User.Login;

public class UserLoginQueryHandlerTests
{

    private readonly UserLoginQueryHandler _handler;
    private readonly IUserQueryRepository _userQueryRepository;
    public UserLoginQueryHandlerTests()
    {
        _userQueryRepository= Substitute.For<IUserQueryRepository>();
        _handler = new UserLoginQueryHandler(_userQueryRepository);
    }

    [Fact]
    public async System.Threading.Tasks.Task Handler_Should_Return_UserInfo()
    {
        // Given
        var command=new UserLoginQuery
        {
          Email = "mustafabarakzey@gmail.com",
          Password="myStrongP@ss"  
        };
        var user = UserModel.Register(command.Email,command.Password);
        user.Id = 1;
        _userQueryRepository.GetByEmailAndPasswordAsync(command.Email,command.Password).Returns(user);

        // When
        var result = await _handler.HandleAsync(command);

        // Then
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.True(result.Data.Id > 0);
    }
}
