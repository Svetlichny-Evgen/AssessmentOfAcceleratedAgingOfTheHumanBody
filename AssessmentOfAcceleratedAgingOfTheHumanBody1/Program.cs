using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.Authentication;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddDbContext<EntityDataBase>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/accessdenied";
            });

            builder.Services.AddScoped<IAccauntRepository, AccauntRepository>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthorizationCore();

            // Register HttpClient with BaseAddress
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAddress") ?? builder.Configuration["https://localhost:5001/"])
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
            });

            var app = builder.Build();

            app.MapPost("/api/auth/signin", async (HttpContext context) =>
            {
                var userInfo = await context.Request.ReadFromJsonAsync<UserInfo>();
                if (userInfo != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userInfo.Name),
                        new Claim(ClaimTypes.Email, userInfo.Email)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = true };
                    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest();
                }
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.MapPost("/account/register", async (AccountModel account, IAccauntRepository repository) =>
            {
                repository.Create(account);
                return Results.Ok();
            });



            app.Run();

        }
    }
}