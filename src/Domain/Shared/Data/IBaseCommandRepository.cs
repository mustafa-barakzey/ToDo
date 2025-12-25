
namespace brk.Todo.Domain.Shared.Data;
public interface IBaseCommandRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetByIdAsync(int id);
}
