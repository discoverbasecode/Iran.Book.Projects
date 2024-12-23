namespace Framework.Application.ResultUtils;

public class OperationResultData<TData> : IOperationResultData<TData>
{
    private const string SuccessMessage = "عملیات با موفقیت انجام شد";
    private const string ErrorMessage = "عملیات با شکست مواجه شد";

    public string Message { get; set; }
    public string Title { get; set; } = null;
    public OperationResultStatus Status { get; set; }
    public TData Data { get; set; }
    public static OperationResultData<TData> Success(TData data)
    {
        return new OperationResultData<TData>()
        {
            Status = OperationResultStatus.Success,
            Message = SuccessMessage,
            Data = data,
        };
    }
    public static OperationResultData<TData> NotFound()
    {
        return new OperationResultData<TData>()
        {
            Status = OperationResultStatus.NotFound,
            Title = "NotFound",
            Data = default,
        };
    }
    public static OperationResultData<TData> Error(string message = ErrorMessage)
    {
        return new OperationResultData<TData>()
        {
            Status = OperationResultStatus.Error,
            Title = "مشکلی در عملیات رخ داده",
            Data = default,
            Message = message
        };
    }
}