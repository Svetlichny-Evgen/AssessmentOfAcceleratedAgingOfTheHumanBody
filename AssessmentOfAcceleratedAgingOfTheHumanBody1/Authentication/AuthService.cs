using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net.Http;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Authentication
{
    public class AuthService
    {
        private readonly IAccauntRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public AuthService(IAccauntRepository accountRepository, IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
        }

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var account = _accountRepository.Select().FirstOrDefault(a => a.EMail == email);
            if (account == null || !PasswordHandler.VerifyPassword(password, account.Password))
            {
                return new LoginResult { Success = false, ErrorMessage = "Неправильный email или пароль" };
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
            var response = await _httpClient.PostAsync("/api/auth/logout", null);
            response.EnsureSuccessStatusCode();
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
        public string ErrorMessage { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
