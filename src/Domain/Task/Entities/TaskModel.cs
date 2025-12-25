
namespace brk.Todo.Domain.Task.Entities;

public class TaskModel : BaseEntity
{
    public string Title { get;private set; }
    public string Description { get;private  set; }

    private TaskModel() { }
    public static TaskModel Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("title is required");
            var model = new TaskModel();
        model.Title = title;
        model.Description = description;
        return model;
    }
}