using brk.Todo.Application.Task.UpdateDescription;
using brk.Todo.Domain.Task.Data;
using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.ApplicationTests.Task.UpdateDescription;

public class UpdateDescriptionCommandHandlerTests
{

    private readonly int _userId = 1;
    private readonly TaskUpdateDescriptionCommandHandler _Handler;
    private readonly ITaskCommandRepository _taskCommandRepository;
    private readonly ICurrentUser _currentUser;
    public UpdateDescriptionCommandHandlerTests()
    {
        _currentUser = Substitute.For<ICurrentUser>();
        _taskCommandRepository = Substitute.For<ITaskCommandRepository>();
        _Handler = new TaskUpdateDescriptionCommandHandler(_currentUser,_taskCommandRepository);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateDescription_Should_UpdateTaskTitle()
    {
        // Given
        var command = new TaskUpdateDescriptionCommand(){Id = 1,Description = "new task desc"};
        var model = TaskModel.Create(_userId,"title",command.Description);
        model.Id = command.Id;
        _currentUser.GetUserId().Returns(_userId);
        _taskCommandRepository.GetAsync(_userId,command.Id).Returns(model);

        // When
        var result = await _Handler.HandleAsync(command);

        // Then
        await _taskCommandRepository.Received().GetAsync(_userId,command.Id);
        await _taskCommandRepository.Received().UpdateAsync(model);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateDescription_Should_Return_NotFound()
    {
        // Given
        var command = new TaskUpdateDescriptionCommand(){Id = 1,Description = "new task desc"};

        _currentUser.GetUserId().Returns(_userId);
        _taskCommandRepository.GetAsync(_userId,command.Id).ReturnsNull();

        // When
        var result = await _Handler.HandleAsync(command);

        // Then
        await _taskCommandRepository.Received().GetAsync(_userId,command.Id);
        await _taskCommandRepository.DidNotReceive().UpdateAsync(Arg.Any<TaskModel>());
        Assert.False(result.IsSuccess);
    }
}
