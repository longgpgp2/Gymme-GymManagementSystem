using GMS.Business.Middlewares;
using GMS.Data;
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


app.Run();

