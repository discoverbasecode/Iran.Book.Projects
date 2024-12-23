namespace Framework.Application.ResultUtils;

public interface IOperationResultData<TData>
{
    string Message { get; set; }
    string Title { get; set; }
    OperationResultStatus Status { get; set; }
    TData Data { get; set; }
}