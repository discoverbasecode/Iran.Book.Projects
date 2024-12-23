namespace Framework.Application.ResultUtils;

public interface IOperationResult
{
    string Message { get; set; }
    string? Title { get; set; }
    OperationResultStatus Status { get; set; }
}