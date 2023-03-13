using System.Reflection;
using System.Text;
using Bugtracker_api_net.Data;
using Bugtracker_api_net.Entities.Common;
using Bugtracker_api_net.Interfaces;
using Bugtracker_api_net.Repositories.Auth.Commands;
using Bugtracker_api_net.Services;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;

namespace Bugtracker_api_net;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
        });


        // Jwt Authentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "BugTracker",
                    ValidAudience = "BugTracker",
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("some-super-secret-key")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = false
                });

        services.AddDbContext<DataContext>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<PasswordHasher<UserBase>>();
        
        // Fluent validation 
        services.AddValidatorsFromAssemblyContaining<RegisterManagerCommandValidator>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


        return services;
    }
}