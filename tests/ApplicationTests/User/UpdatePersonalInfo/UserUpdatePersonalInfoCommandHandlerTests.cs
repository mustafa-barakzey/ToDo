using brk.Todo.Application.Shared.Contracts;
using brk.Todo.Application.User.UpdatePersonalInfo;
using brk.Todo.Domain.User.Data;
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.ApplicationTests.User;

public class UserUpdatePersonalInfoCommandHandlerTests
{

    const int userId = 1;
    private readonly UserUpdatePersonalInfoCommandHandler _handler;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly ICurrentUser _currentUser;
    public UserUpdatePersonalInfoCommandHandlerTests()
    {
        _userCommandRepository= Substitute.For<IUserCommandRepository>();
        _currentUser= Substitute.For<ICurrentUser>();
        _handler = new UserUpdatePersonalInfoCommandHandler(_currentUser,_userCommandRepository);
    }

    [Fact]
    public async Task Handler_Should_UpdatePersonalInfo()
    {
        // Given
        const int userId = 1;
        var command = GetCommand();

        var user = UserModel.Register("me@gmail.com", "P@SS123");
        _currentUser.GetUserId().Returns(userId);
        _userCommandRepository.GetByIdAsync(userId).Returns(user);

        // When
        var result = await _handler.HandleAsync(command);

        // Then
        await _userCommandRepository.Received()
                                .GetByIdAsync(userId);

        await _userCommandRepository.Received()
                                .UpdateAsync(user);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task Handler_Should_Return_UserNotFound()
    {
        // Given
        var command = GetCommand();

        var user= UserModel.Register("me@gmail.com","P@SS123");
        _currentUser.GetUserId().Returns(userId);
        _userCommandRepository.GetByIdAsync(userId).ReturnsNull();

        // When
        var result = await _handler.HandleAsync(command);
        
        // Then
        await _userCommandRepository.Received()
                                .GetByIdAsync(userId);

        await _userCommandRepository.DidNotReceive()
                                .UpdateAsync(user);

        Assert.False(result.IsSuccess);
    }


    private static UserUpdatePersonalInfoCommand GetCommand()
    {
        return new UserUpdatePersonalInfoCommand
        {
            Name = "John",
            Family = "due"
        };
    }

}
