using BlazorWASMClient.Application.Repositories.Interface;
using StrawberryShake;

namespace BlazorWASMClient.Application.Repositories.Service;

public class AuthService(IR2YGqlClient client, ITokenService tokenService) : IAuthService
{
    public async Task< IUserLogin_Login?> LoginAsync(string email, string password,
        CancellationToken cancellationToken = default)
    {
        var result = await client.UserLogin.ExecuteAsync(email, password, cancellationToken);
        result.EnsureNoErrors();
        
        var login = result.Data!.Login;
        
        await tokenService.SetTokenAsync(login.Token);
        return login;
    }

    public async Task<IReadOnlyList<IGetAllUsers_AllUsers_Nodes>?> GetUsersWithStrawberryShake()
    {
        var result = await client.GetAllUsers.ExecuteAsync(null, null);
        result.EnsureNoErrors();
		
        return result.Data!.AllUsers!.Nodes;
    }
}