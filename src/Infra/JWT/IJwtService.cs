namespace brk.Todo.Infra.JWT;

public interface IJwtService
{
    Task<string>  GenerateToken(int userId,Dictionary<string,string> claims);
}
