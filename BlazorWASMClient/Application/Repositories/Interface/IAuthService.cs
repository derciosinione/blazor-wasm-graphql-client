﻿namespace BlazorWASMClient.Application.Repositories.Interface;

public interface IAuthService
{
    Task< IUserLogin_Login?> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<IGetAllUsers_AllUsers_Nodes>?> GetUsersWithStrawberryShake();
}