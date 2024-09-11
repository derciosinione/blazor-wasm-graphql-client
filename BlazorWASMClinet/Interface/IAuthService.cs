using WebApiGraphQLClient.Response;

namespace BlazorWASMClinet.Interface;

public interface IAuthService
{
    Task<LoginData> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
    
    Task<string> GetInMemoryToken(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<IGetAllUsers_AllUsers_Nodes>?> GetUsersWithStrawberryShake();
}