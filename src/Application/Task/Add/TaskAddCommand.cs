
namespace brk.Todo.Application.Task.Add;

public class TaskAddCommand: ICommand
{
    public string Title { get; set; }
    public string? Description { get; set; }
}
