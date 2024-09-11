using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASMClinet;
using BlazorWASMClinet.Interface;
using BlazorWASMClinet.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services
    .AddR2YGqlClient()
    .ConfigureHttpClient(ConfigureClient);
    
await builder.Build().RunAsync();
return;


async void ConfigureClient(IServiceProvider sp, HttpClient client)
{
    client.BaseAddress = new Uri("https://localhost:8081/graphql");

    var localStorage = sp.GetRequiredService<ILocalStorageService>();
    var token = await localStorage.GetItemAsync<string>("jwt_token");

    if (!string.IsNullOrEmpty(token))
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}