namespace AccessControl.Application.Responses;

<<<<<<<< HEAD:src/Backend/AccessControl/Application/Responses/RegisterRoleApplicationResponse.cs
public sealed class RegisterRoleApplicationResponse
========
public sealed class RegisterRoleResponse
>>>>>>>> 983277a (merge from julian to main):src/Backend/AccessControl/Application/Responses/RegisterRoleResponse.cs
{
    public required string RoleId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Disabled { get; init; }
}
