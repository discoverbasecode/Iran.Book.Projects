using MediatR;

namespace Framework.Application.MediatorUtils;
public static class MediatorHelper
{
    public static async Task<TResponse> SendRequest<TResponse>(IMediator mediator, IRequest<TResponse> request)
    {
        if (mediator == null) throw new ArgumentNullException(nameof(mediator));
        return await mediator.Send(request);
    }

    public static async Task<Unit> SendCommand(IMediator mediator, IRequest<Unit> command)
    {
        if (mediator == null) throw new ArgumentNullException(nameof(mediator));
        return await mediator.Send(command);
    }
}