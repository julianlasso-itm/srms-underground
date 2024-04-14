using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class GetRolesHelper : IHelper<GetRolesRequest, GetRolesResponse>
{
    public static void Execute() { }

    public static GetRolesResponse Execute(GetRolesRequest data)
    {
        throw new NotImplementedException();
    }
}

internal class GetRolesResponse { }

internal class GetRolesRequest { }
