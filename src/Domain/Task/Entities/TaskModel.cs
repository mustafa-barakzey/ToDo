
namespace brk.Todo.Domain.Task.Entities;

public class TaskModel : BaseEntity
{
    public int UserId { get;private set; }
    public string Title { get;private set; }
    public string? Description { get;private  set; }

    private TaskModel() { }
    public static TaskModel Create(int userId,string title, string? description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("title is required");
        var model = new TaskModel();
        model.UserId = userId;
        model.Title = title;
        model.Description = description;
        return model;
    }

    public void UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("title is required");

        Title = title;
    }

    public void UpdateDescription(string? desciption)
    {
        Description = desciption;
    }
}