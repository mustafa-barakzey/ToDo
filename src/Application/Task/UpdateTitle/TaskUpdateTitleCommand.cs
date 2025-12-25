using System;

namespace brk.Todo.Application.Task.UpdateTitle;

public class TaskUpdateTitleCommand : ICommand
{
    [Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "Id is not valid")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }
}
