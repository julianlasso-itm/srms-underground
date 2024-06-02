namespace Shared.Domain
{
  public interface IResultDomain<Type> {
    public IResultDomain<Type> Success(Type value);
    public IResultDomain<Type> Failure(string error);
  }
}
