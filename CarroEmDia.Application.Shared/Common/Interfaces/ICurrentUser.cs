namespace CarroEmDia.Application.Shared.Common.Interfaces
{
    public interface ICurrentUser
    {
        int? Id { get; }
        string? Name { get; }
        string? Email { get; }
        bool IsAuthenticated { get; }
    }
}
