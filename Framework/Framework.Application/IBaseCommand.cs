using MediatR;

namespace Framework.Application
{
    public interface IBaseCommand : IRequest<OperationResult> { }

    public interface IBaseCommand<TData> : IRequest<OperationResult<TData>> { }
}