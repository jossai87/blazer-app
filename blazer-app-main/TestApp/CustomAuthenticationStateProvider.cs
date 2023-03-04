using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider: AuthenticationStateProvider {

//Return Auth state
public override async Task<AuthenticationState> GetAuthenticationStateAsync(){
    return await Task.FromResult(new AuthenticationState(AnonymousUser));
}

//Ability to check Auth state (sign in / sign out)
private ClaimsPrincipal AnonymousUser => new(new ClaimsIdentity(Array.Empty<Claim>()));

//delcare fake user
private ClaimsPrincipal RegularFakdeUser{
    get{
        var claims = new[] {
            new Claim(ClaimTypes.Name, "john"),
            new Claim(ClaimTypes.Role, "user"),
        };
        var identity = new ClaimsIdentity(claims, "faked");
        return new ClaimsPrincipal(identity);

    }
}

private ClaimsPrincipal AdminFakedUser{
    get{
        var claims = new[] {
            new Claim(ClaimTypes.Name, "sally"),
            new Claim(ClaimTypes.Role, "admin"),
        };
        var identity = new ClaimsIdentity(claims, "faked");
        return new ClaimsPrincipal(identity);
    }
}

//Methods for signing in and out
public void RegularFakedSignIn(){
    var results = Task.FromResult(new AuthenticationState(RegularFakdeUser));
    NotifyAuthenticationStateChanged(result)
}

public void AdminFakedSignIn(){
    var results = Task.FromResult(new AuthenticationState(AdminFakdeUser));
    NotifyAuthenticationStateChanged(result)
}

public void SignOut(){
    var results = Task.FromResult(new AuthenticationState(AnonymousUser));
    NotifyAuthenticationStateChanged(result)
}

} 