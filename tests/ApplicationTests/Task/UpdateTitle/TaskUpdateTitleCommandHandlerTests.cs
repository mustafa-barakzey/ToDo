using brk.Todo.Application.Task.UpdateTitle;
using brk.Todo.Domain.Task.Data;
using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.ApplicationTests.Task.UpdateTitle;

public class TaskUpdateTitleCommandHandlerTests
{
    private readonly int _userId = 1;
    private readonly TaskUpdateTitleCommandHandler _Handler;
    private readonly ITaskCommandRepository _taskCommandRepository;
    private readonly ICurrentUser _currentUser;
    public TaskUpdateTitleCommandHandlerTests()
    {
        _currentUser = Substitute.For<ICurrentUser>();
        _taskCommandRepository = Substitute.For<ITaskCommandRepository>();
        _Handler = new TaskUpdateTitleCommandHandler(_currentUser,_taskCommandRepository);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateTitle_Should_UpdateTaskTitle()
    {
        // Given
        var command = new TaskUpdateTitleCommand(){Id = 1,Title = "new task title"};
        var model = TaskModel.Create(_userId,command.Title,string.Empty);
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
    public async System.Threading.Tasks.Task UpdateTitle_Should_Return_NotFound()
    {
        // Given
        var command = new TaskUpdateTitleCommand(){Id = 1,Title = "new task title"};

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
