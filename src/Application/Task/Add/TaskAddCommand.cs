
namespace brk.Todo.Application.Task.Add;

public class TaskAddCommand: ICommand
{
    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }
    public string? Description { get; set; }
}
