# Add package for GMS.Models
dotnet add GMS.Models package Microsoft.EntityFrameworkCore
dotnet add GMS.Models package Microsoft.AspNetCore.Identity.EntityFrameworkCore

# Add package for GMS.Business
dotnet add GMS.Business package Microsoft.EntityFrameworkCore
dotnet add GMS.Business package MediatR
dotnet add GMS.Business package AutoMapper
dotnet add GMS.Business package Newtonsoft.Json

# Add package for GMS.Data
dotnet add GMS.Data package Microsoft.EntityFrameworkCore
dotnet add GMS.Data package Microsoft.EntityFrameworkCore.SqlServer
dotnet add GMS.Data package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add GMS.Data package Microsoft.AspNetCore.Identity

# Add package for GMS.API
dotnet add GMS.API package Microsoft.EntityFrameworkCore
dotnet add GMS.API package Microsoft.EntityFrameworkCore.SqlServer
dotnet add GMS.API package Microsoft.EntityFrameworkCore.Design
dotnet add GMS.API package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add GMS.API package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add GMS.API package Microsoft.AspNetCore.Identity.UI
dotnet add GMS.API package Microsoft.AspNetCore.API.NewtonsoftJson
dotnet add GMS.API package Microsoft.AspNetCore.API.Versioning
dotnet add GMS.API package Microsoft.AspNetCore.API.Versioning.ApiExplorer
dotnet add GMS.API package Swashbuckle.AspNetCore
dotnet add GMS.API package Swashbuckle.AspNetCore.Swagger
dotnet add GMS.API package Swashbuckle.AspNetCore.SwaggerGen
dotnet add GMS.API package Swashbuckle.AspNetCore.SwaggerUI
dotnet add GMS.API package Microsoft.Extensions.Configuration
