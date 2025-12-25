

using brk.Todo.Domain.Task.Data;

namespace brk.Todo.Application.Task.UpdateTitle;

public class TaskUpdateTitleCommandHandler(ICurrentUser currentUser,ITaskCommandRepository taskCommandRepository) : ICommandHandler<TaskUpdateTitleCommand>
{
    public async Task<CommandResponse> HandleAsync(TaskUpdateTitleCommand command)
    {
        var model = await taskCommandRepository.GetAsync(currentUser.GetUserId(),command.Id);
        if(model is null)
            return CommandResponse.Faild("Task not found");
        
        model.UpdateTitle(command.Title);
        await taskCommandRepository.UpdateAsync(model);
        return CommandResponse.Success("Title updated");
    }
}
