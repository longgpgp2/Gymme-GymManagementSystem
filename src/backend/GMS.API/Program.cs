using GMS.Business.Middlewares;
using GMS.Data;
using GMS.Data.SeedData;
using GMS.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.RegisterServicesAndMediatR(builder.Configuration);

builder.Services.RegisterAuthentication(builder.Configuration);

builder.Services.RegisterSwagger(builder.Configuration);

builder.Services.RegisterCors(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<GMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<GMSDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

    var rolesJsonPath = Path.Combine(app.Environment.WebRootPath, "data", "role.json");
    var usersJsonPath = Path.Combine(app.Environment.WebRootPath, "data", "user.json");

    try
    {
        await DbInitializer.Initialize(context, roleManager, userManager, rolesJsonPath, usersJsonPath);
        Console.WriteLine("Database seeded successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding database: {ex.Message}");
    }

    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GMS Web API v1");
        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseHttpsRedirection();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();

