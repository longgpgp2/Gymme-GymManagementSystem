# Migrations

## 1. Using the CLI

### Add a migration
```bash
dotnet ef migrations add AddBaseEntityModel --project GMS.Data --startup-project GMS.API --context GMSDbContext --output-dir Migrations
dotnet ef migrations add [MigrationName] --project GMS.API --startup-project GMS.API --context GMSDbContext --output-dir Migrations
dotnet ef migrations add UpdateUserNote --project GMS.Data --startup-project GMS.API --context GMSDbContext --output-dir Migrations
```

### Update the database
```bash
dotnet ef database update --project GMS.Data --startup-project GMS.API --context GMSDbContext
dotnet ef database update --project GMS.Data --startup-project GMS.API --context GMSDbContext
```

### Roll back a migration
```bash
dotnet ef database update [MigrationName] --project GMS.Data --startup-project GMS.API --context GMSDbContext
dotnet ef database update [MigrationName] --project GMS.Data --startup-project GMS.API --context GMSDbContext
```

### Drop the database
```bash
dotnet ef database drop --project GMS.API --startup-project GMS.API --context GMSDbContext
dotnet ef database drop --project GMS.Data --startup-project GMS.API --context GMSDbContext
```

### Remove a migration
```bash
dotnet ef migrations remove --project GMS.Data --startup-project GMS.API --context GMSDbContext
dotnet ef migrations remove --project GMS.Data --startup-project GMS.API --context GMSDbContext
```

## 2. Using the Package Manager Console
### Add a migration
```bash
Add-Migration [MigrationName] -Project GMS.Data -StartupProject GMS.API -Context GMSDbContext -OutputDir GMS.Data/Migrations
```

### Update the database
```bash
Update-Database -Project GMS.Data -StartupProject GMS.API -Context GMSDbContext
```

### Roll back a migration
```bash
Update-Database [MigrationName] -Project GMS.Data -StartupProject GMS.API -Context GMSDbContext
```

### Remove a migration
```bash
Remove-Migration -Project GMS.Data -StartupProject GMS.API -Context GMSDbContext
```

[]: # Path: README.md
