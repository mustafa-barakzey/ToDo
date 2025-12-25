using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.UnitTests.Task.Entities;

public class TaskModelTests
{
    [Fact]
    public void Create_Should_CreateNew()
    {
        // Given
        var title = "task-1";
        var description = "task-1 description";
    
        // When
        var task= TaskModel.Create(title,description);

        // Then
        Assert.Equal(title,task.Title);
        Assert.Equal(description,task.Description);
    }

    [Fact]
    public void Create_Should_Throw_TitleIsRequired()
    {
        // Given
        var title = string.Empty;
        var description = "task-1 description";
    
        // When
        var action =()=> TaskModel.Create(title,description);
    
        // Then
        Assert.Throws<DomainException>(action);
    }
}

