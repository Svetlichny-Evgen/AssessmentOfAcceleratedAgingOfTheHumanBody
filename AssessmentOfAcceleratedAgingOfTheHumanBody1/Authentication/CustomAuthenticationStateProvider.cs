using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
