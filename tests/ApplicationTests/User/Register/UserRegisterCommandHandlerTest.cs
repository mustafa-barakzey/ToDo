
using brk.Todo.Application.User.Register;
using brk.Todo.Domain.User.Data;
using brk.Todo.Domain.User.Entities;


namespace brk.Todo.ApplicationTests.User.Register;

public class UserRegisterCommandHandlerTest
{
    private readonly UserRegisterCommandHandler _handler;
    private readonly IUserCommandRepository _userCommandRepository;
    public UserRegisterCommandHandlerTest()
    {
        _userCommandRepository= Substitute.For<IUserCommandRepository>();
        _handler = new UserRegisterCommandHandler(_userCommandRepository);
    }

    [Fact]
    public async System.Threading.Tasks.Task Handler_Should_RegisterNewUser()
    {
        // Given
        var command = new UserRegisterCommand()
        {
            Email ="mustafabarakzey@gmail.com",
            Password ="myStr0ngP@ss"
        };

        // When
        var result = await _handler.HandleAsync(command);

        // Then
        Assert.True(result.IsSuccess);
        await _userCommandRepository
                .Received()
                .AddAsync(Arg.Any<UserModel>());
    }

    [Fact]
    public async System.Threading.Tasks.Task Handler_Should_Return_EmailIsAlreadyExist()
    {
        // Given
        var command = new UserRegisterCommand()
        {
            Email ="mustafabarakzey@gmail.com",
            Password ="myStr0ngP@ss"
        };

        _userCommandRepository.IsEmailAlreadyExistAsync(command.Email).Returns(true);

        // When
        var result = await _handler.HandleAsync(command);

        // Then
        await _userCommandRepository
                .DidNotReceive()
                .AddAsync(Arg.Any<UserModel>());
        Assert.False(result.IsSuccess);
    }
}
