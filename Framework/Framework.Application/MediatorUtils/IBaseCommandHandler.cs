using Framework.Application.ResultUtils;
using MediatR;

namespace Framework.Application.MediatorUtils;

public interface IBaseCommandHandler<in TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IBaseCommand
{
}

public interface IBaseCommandHandler<in TCommand, TResponseData> : IRequestHandler<TCommand, OperationResultData<TResponseData>> where TCommand : IBaseCommand<TResponseData>
{
}