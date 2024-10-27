using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Web;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;

    public CustomAuthStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new ClaimsPrincipal());

        var id = await _localStorage.GetItemAsync<string>("id");
        if (!string.IsNullOrEmpty(id))
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, id) }, "jwt");
            state = new AuthenticationState(new ClaimsPrincipal(identity));
        }

        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }
}