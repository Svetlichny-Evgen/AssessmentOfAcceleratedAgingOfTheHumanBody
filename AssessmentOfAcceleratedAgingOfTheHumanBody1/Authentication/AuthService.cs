using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Authentication
{
    public class AuthService
    {
        private readonly IAccauntRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IAccauntRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var account = _accountRepository.Select().FirstOrDefault(a => a.EMail == email && a.Password == password);
            if (account == null)
            {
                return false;
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, account.FullName),
            new Claim(ClaimTypes.Email, account.EMail)
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return true;
        }

        public async Task LogoutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
