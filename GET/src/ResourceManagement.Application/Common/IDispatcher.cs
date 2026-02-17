namespace ResourceManagement.Application.Common;

public interface IDispatcher
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>;
}
