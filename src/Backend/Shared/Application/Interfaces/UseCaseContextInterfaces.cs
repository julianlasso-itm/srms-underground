namespace Shared.Application.Interfaces;

public interface IUseCaseContext<Command, Response>
{
    Task<Response> ExecuteAsync(Command request);
}
