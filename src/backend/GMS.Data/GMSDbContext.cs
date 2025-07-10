using System;
using GMS.Models.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GMS.Data;

public class GMSDbContext : IdentityDbContext<User, Role, Guid>
{
    public GMSDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

}
