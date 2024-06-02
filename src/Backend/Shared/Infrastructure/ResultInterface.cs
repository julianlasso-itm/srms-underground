namespace Shared.Infrastructure
{
  public interface IResultInfrastructure<Type>
  {
    IResultInfrastructure<Type> Success(Type value);
    IResultInfrastructure<Type> Failure(string error);
  }
}
