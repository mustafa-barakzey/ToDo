
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.Domain.User.Data;

public interface IUserCommandRepository : IBaseCommandRepository<UserModel>
{
    Task<bool> IsEmailAlreadyExistAsync(string email);
}
