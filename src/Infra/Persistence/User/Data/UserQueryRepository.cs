using brk.Todo.Domain.User.Data;
using brk.Todo.Domain.User.Entities;
using brk.Todo.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace brk.Todo.Infra.Persistence.User.Data;

public class UserQueryRepository(QueryDbContext context) : IUserQueryRepository
{
    public async Task<UserModel?> GetByEmailAndPasswordAsync(string email, string password)
         => await context.Set<UserModel>().FirstOrDefaultAsync(m=>m.Email == email && m.Password == password);

}
