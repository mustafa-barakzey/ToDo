using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.UnitTests.Task.Entities;

public class TaskModelTests
{
    private readonly int UserId = 1;
    private readonly string Title = "task-1";
    private readonly string Description = "task-1 description";
    [Fact]
    public void Create_Should_CreateNew()
    {
        // Given

        // When
        var task= TaskModel.Create(UserId,Title,Description);

        // Then
        Assert.Equal(UserId,task.UserId);
        Assert.Equal(Title,task.Title);
        Assert.Equal(Description,task.Description);
    }

    [Fact]
    public void Create_Should_Throw_TitleIsRequired()
    {
        // Given
        var title = string.Empty;
    
        // When
        var action =()=> TaskModel.Create(UserId,title,Description);
    
        // Then
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void UpdateTitle_Should_UpdateTitle()
    {
        // Given
        var newTitle="updated title";
        var task = TaskModel.Create(UserId,newTitle,Description);
        // When
        task.UpdateTitle(newTitle);
        // Then
        Assert.Equal(newTitle,task.Title);
    }

    [Fact]
    public void UpdateTitle_Should_Throw_WhenTitleIsEmpty()
    {
        // Given
        var newTitle = string.Empty;
        var task = TaskModel.Create(UserId,Title,Description);
        // When
        var action = () => task.UpdateTitle(newTitle);

        // Then
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void UpdateDescription_Should_UpdateDescription()
    {
        // Given
        var newDesciption="updated Desciption";
        var task = TaskModel.Create(UserId,Title,Description);
        // When
        task.UpdateDescription(newDesciption);
        // Then
        Assert.Equal(newDesciption,task.Description);
    }
}

