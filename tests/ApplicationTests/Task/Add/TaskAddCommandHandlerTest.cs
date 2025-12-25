
using brk.Todo.Application.Shared.Contracts;
using brk.Todo.Application.Task.Add;
using brk.Todo.Domain.Task.Data;
using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.ApplicationTests.Task.Add;

public class TaskAddCommandHandlerTest
{
    private readonly ITaskCommandRepository _taskCommandRepository;
    private readonly TaskAddCommandHandler _handler;
    private readonly ICurrentUser _currentUser;
    public TaskAddCommandHandlerTest()
    {
        _taskCommandRepository = Substitute.For<ITaskCommandRepository>();
        _currentUser = Substitute.For<ICurrentUser>();
        _handler = new TaskAddCommandHandler(_currentUser,_taskCommandRepository);
    }

    [Fact]
    public async System.Threading.Tasks.Task Handler_Should_AddNew()
    {
        // Given
        var command = new TaskAddCommand()
        {
            Title = "task-01",
            Description = "task-01 description"
        };

        // When
        var result= await _handler.HandleAsync(command);
        
        // Then
        await _taskCommandRepository.Received().AddAsync(Arg.Any<TaskModel>());
        Assert.True(result.IsSuccess);
    }
}
