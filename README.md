# MusicComplexApi - generated skeleton
Structure created for Rider usage. Projects:
- MusicComplexApi (Web API)
- MusicComplexModels (Entities)
- MusicComplexRepositories (EF Core + Generic repository)
- MusicComplexServices (Generic services)

Connection string configured in MusicComplexApi/appsettings.json to:
Host=localhost;Port=5435;Database=postgres;Username=user;Password=1111

Instructions:
1. Open the folder in Rider as a solution folder.
2. Restore NuGet packages, build the solution.
3. Run `MusicComplexApi` project. Swagger UI available in development.


## Migrations & Seeding

To create and apply EF Core migrations (requires dotnet-ef tool):

```bash
# install tools if not installed
dotnet tool install --global dotnet-ef

# create migration
dotnet ef migrations add InitialCreate --project MusicComplexRepositories --startup-project MusicComplexApi

# apply migration to DB
dotnet ef database update --project MusicComplexRepositories --startup-project MusicComplexApi
```

The application will also call `Database.Migrate()` on startup and run a simple data seeder (`DataSeeder.SeedAsync`) if the DB is empty.
