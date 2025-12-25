namespace brk.Todo.Application.Shared.Contracts;

public interface ICommandHandler<TCommand> where TCommand: ICommand
{
    Task<CommandResponse> HandleAsync(TCommand command);
}

public class CommandResponse
{
    public string? Message { get;init; }
    public bool IsSuccess { get; init; }

    public static CommandResponse Success(string message = "The operation was successful.")=>new()
    {
        Message = message,
        IsSuccess = true
    };

    public static CommandResponse Faild(string message = "The operation failed.")=>new()
    {
        Message = message,
        IsSuccess = false
    };

}