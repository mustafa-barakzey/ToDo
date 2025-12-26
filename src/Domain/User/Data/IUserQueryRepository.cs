
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.Domain.User.Data;

public interface IUserQueryRepository : IBaseQueryRepository<UserModel>
{
    Task<UserModel?> GetByEmailAndPasswordAsync(string email, string password);
}
