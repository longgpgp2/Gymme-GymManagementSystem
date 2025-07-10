using System;
using System.Text;
using GMS.Data;
using GMS.Models.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GMS.API.Middlewares;


public static class ServiceExtensions
{

    public static IServiceCollection RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Identity: UserManager, RoleManager, SignInManager
        services.AddIdentity<User, Role>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<GMSDbContext>()
            .AddDefaultTokenProviders();

        // Register JWT with Bearer token
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    configuration["JWT:Secret"] ?? "supersecuredsecretkey"))
            };
        });
        return services;
    }

    public static IServiceCollection RegisterServicesAndMediatR(this IServiceCollection services, IConfiguration configuration)
    {
        
        return services;
    }

    public static IServiceCollection RegisterSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "ViVuStore Web API", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        }
                                    },
                                    new string[] { }
                                }
                            });
            });

        return services;
    }


    public static IServiceCollection RegisterCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", opt => opt
                .WithOrigins(configuration.GetSection("CORs:AllowedOrigins").Get<string[]>() ?? [])
                .WithHeaders(configuration.GetSection("CORs:AllowedHeaders").Get<string[]>() ?? [])
                .WithMethods(configuration.GetSection("CORs:AllowedMethods").Get<string[]>() ?? []));

            options.AddPolicy("AllowAnyOrigin", opt => opt
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        return services;
    }


}
