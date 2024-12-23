using Framework.Application.ResultUtils;
using MediatR;

namespace Framework.Application.MediatorUtils
{
    public interface IBaseCommand : IRequest<OperationResult> { }

    public interface IBaseCommand<TData> : IRequest<OperationResultData<TData>> { }
}