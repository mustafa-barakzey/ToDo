
using Microsoft.EntityFrameworkCore;

namespace brk.Todo.Infra.Persistence.Contexts;

public class CommandDbContext : DbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> options):base(options)
    {
        
    }
}
