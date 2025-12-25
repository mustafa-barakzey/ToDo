using brk.Todo.Domain.Task.Data;
using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.Application.Task.Add;

public class TaskAddCommandHandler(ICurrentUser currentUser, ITaskCommandRepository taskCommandRepository) : ICommandHandler<TaskAddCommand>
{
    public async Task<CommandResponse> HandleAsync(TaskAddCommand command)
    {
        var task = TaskModel.Create(currentUser.GetUserId(),command.Title,command.Description);

        await taskCommandRepository.AddAsync(task);

        return CommandResponse.Success("Task added");
    }
}
