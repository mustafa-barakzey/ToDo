
namespace brk.Todo.Application.Task.UpdateDescription;

public class TaskUpdateDescriptionCommand:ICommand
{  
    [Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "Id is not valid")]
    public int Id { get; set; }
    public string? Description { get; set; }
}
