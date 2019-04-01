# MarketOrganizer
Add Connection String as
```json
"ConnectionStrings": {
  "DbString": "Server=localhost;Database=market_org;User Id=sa;Password=Password1!;"
}
``` 
in  appsettings.Development.json
- `dotnet restore`
- `dotnet run -p MarketOrganizer.Api`

use the switch `-p` to specify the project to run, in this case the API

If you are using the C# Extension in VsCode (or using Full Visual Studio) press <kbd>F5</kbd>

## Migrations
Change to Api Directory
```
D:\github\MarketOrganizer> cd MarketOrganizer.Api
D:\github\MarketOrganizer\MarketOrganizer.Api> dotnet ef migrations add MyMigration -p ../MarketOrganizer.Data
```

## Update Database
Apply migrations
```
D:\github\MarketOrganizer> cd MarketOrganizer.Api
D:\github\MarketOrganizer\MarketOrganizer.Api> dotnet ef database update -p ../MarketOrganizer.Data
```

we use the switch `-p` to specify which project we're using for the migrations/data
