namespace Shared.Application
{
  public interface IResultApplication<Type>
  {
    IResultApplication<Type> Success(Type value);
    IResultApplication<Type> Failure(string error);
  }
}
