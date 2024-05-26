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

            var app = builder.Build();

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

            app.MapPost("/account/login", async (HttpContext httpContext, AuthService authService, string email, string password) =>
            {
                if (await authService.LoginAsync(email, password))
                {
                    return Results.Ok();
                }
                return Results.Unauthorized();
            });

            app.Run();

        }
    }
}