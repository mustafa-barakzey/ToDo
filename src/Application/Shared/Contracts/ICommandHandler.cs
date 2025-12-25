namespace brk.Todo.Application.Shared.Contracts;

public interface ICommandHandler<TCommand> where TCommand: ICommand
{
    Task<CommandResponse> HandleAsync(TCommand command);
}

public class CommandResponse(string message)
{
    public string Message { get;init; } = message;
}