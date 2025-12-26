namespace brk.Todo.Application.Shared.Contracts;

public interface IQueryHandler<TCommand,TOut> where TCommand: IQuery<TOut>
{
    Task<QueryResponse<TOut>> HandleAsync(TCommand command);
}

public class QueryResponse<TData> : CommandResponse
{
    public TData? Data { get; init; }

    public static QueryResponse<TData> Success(TData data,string message = "The operation was successful.")=>new QueryResponse<TData>()
    {
        Message = message,
        IsSuccess = true,
        Data = data
    };

    public new static QueryResponse<TData>  Faild(string message = "The operation failed.")=>new()
    {
        Message = message,
        IsSuccess = false
    };
}