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

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var account = _accountRepository.Select().FirstOrDefault(a => a.EMail == email && a.Password == password);
            if (account == null)
            {
                return new LoginResult { Success = false };
            }

            var userInfo = new UserInfo
            {
                Name = account.FullName,
                Email = account.EMail
            };

            return new LoginResult { Success = true, UserInfo = userInfo };
        }

        public async Task SignInAsync(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public async Task LogoutAsync()
        {
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = "/login" // Перенаправляем пользователя на страницу входа после выхода
            };

            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, authProperties);
        }
    }

    public class UserInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
