namespace Shared.Application.Interfaces;

public interface IUseCase<Command, Response>
{
    Task<Response> Handle(Command request);
}
