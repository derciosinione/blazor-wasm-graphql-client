using BlazorWASMClinet.Interface;
using StrawberryShake;
using WebApiGraphQLClient.Response;

namespace BlazorWASMClinet.Service;

public class AuthService : IAuthService
{
    private readonly IR2YGqlClient _client;

    public AuthService(IR2YGqlClient client)
    {
        _client = client;
    }
    
    public async Task<LoginData> LoginAsync(string email, string password,
        CancellationToken cancellationToken = default)
    {
        var result = await _client.UserLogin.ExecuteAsync(email, password, cancellationToken);
      
        result.EnsureNoErrors();
        
        var data = result.Data!.Login;
        
        var token = new LoginData
        {
            Id = data.Id,
            Email = data.Email,
            Token = data.Token
        };
        
        return token;
    }

    public Task<string> GetInMemoryToken(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(string.Empty);
    }
    
    public async Task<IReadOnlyList<IGetAllUsers_AllUsers_Nodes>?> GetUsersWithStrawberryShake()
    {
        var result = await _client.GetAllUsers.ExecuteAsync(null, null);
        result.EnsureNoErrors();
		
        return result.Data!.AllUsers!.Nodes;
    }
}