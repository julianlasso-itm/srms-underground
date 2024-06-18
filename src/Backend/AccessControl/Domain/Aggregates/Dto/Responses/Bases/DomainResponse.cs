using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses.Bases
{
  public abstract class DomainResponse
  {
    public abstract Type Accept<Type>(IDomainResponseVisitor<Type> visitor);
  }
}
