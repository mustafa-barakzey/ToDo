using brk.Todo.Domain.Task.Data;

namespace brk.Todo.Application.Task.UpdateDescription;

public class TaskUpdateDescriptionCommandHandler(ICurrentUser currentUser,ITaskCommandRepository taskCommandRepository) : ICommandHandler<TaskUpdateDescriptionCommand>
{
    public async Task<CommandResponse> HandleAsync(TaskUpdateDescriptionCommand command)
    {
        var model = await taskCommandRepository.GetAsync(currentUser.GetUserId(),command.Id);
        if(model is null)
            return CommandResponse.Faild("Task not found");
        
        model.UpdateDescription(command.Description);
        await taskCommandRepository.UpdateAsync(model);
        return CommandResponse.Success("Description updated");
    }
}
