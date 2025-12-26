using brk.Todo.Domain.Task.Data;
using brk.Todo.Domain.Task.Entities;
using brk.Todo.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace brk.Todo.Infra.Persistence.Task.Data;

public class TaskCommandRepository(CommandDbContext context) : ITaskCommandRepository
{
    public async ValueTask AddAsync(TaskModel entity)
    {
        await context.Set<TaskModel>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<TaskModel?> GetAsync(int userId, int taskId)
        => await context.Set<TaskModel>().FirstOrDefaultAsync(m=>m.Id == taskId && m.UserId == userId);

    public async Task<TaskModel?> GetByIdAsync(int id)
        => await context.Set<TaskModel>().FirstOrDefaultAsync(m=>m.Id == id);

    public async ValueTask UpdateAsync(TaskModel entity)
    {
        context.Set<TaskModel>().Update(entity);
        await context.SaveChangesAsync();
    }
}
