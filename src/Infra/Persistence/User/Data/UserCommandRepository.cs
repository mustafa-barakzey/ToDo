using brk.Todo.Domain.User.Data;
using brk.Todo.Domain.User.Entities;
using brk.Todo.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace brk.Todo.Infra.Persistence.User.Data;

public class UserCommandRepository(CommandDbContext context) : IUserCommandRepository
{
    public async ValueTask AddAsync(UserModel entity)
    {
        await context.Set<UserModel>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<UserModel?> GetByIdAsync(int id)
            => await context.Set<UserModel>().FirstOrDefaultAsync(m=>m.Id == id);


    public async Task<bool> IsEmailAlreadyExistAsync(string email)
            => await context.Set<UserModel>().AnyAsync(m=>m.Email == email);

    public async ValueTask UpdateAsync(UserModel entity)
    {
        context.Set<UserModel>().Update(entity);
        await context.SaveChangesAsync();
    }
}
