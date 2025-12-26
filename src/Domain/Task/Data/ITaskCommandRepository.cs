using brk.Todo.Domain.Task.Entities;

namespace brk.Todo.Domain.Task.Data;

public interface ITaskCommandRepository : IBaseCommandRepository<TaskModel>
{
    Task<TaskModel?> GetAsync(int userId,int taskId);
}
