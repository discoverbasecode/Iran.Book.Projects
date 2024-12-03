using MediatR;

namespace Framework.Application
{
    public interface IBaseCommandHandler<in TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IBaseCommand
    {
    }

    public interface IBaseCommandHandler<in TCommand, TResponseData> : IRequestHandler<TCommand, OperationResult<TResponseData>> where TCommand : IBaseCommand<TResponseData>
    {
    }
}