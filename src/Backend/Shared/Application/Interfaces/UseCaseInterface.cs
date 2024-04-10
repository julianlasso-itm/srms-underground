namespace Shared.Application.Interfaces;

public interface IUseCase<TCommand, TResponse>
{
    Task<TResponse> Handle(TCommand request);
}
