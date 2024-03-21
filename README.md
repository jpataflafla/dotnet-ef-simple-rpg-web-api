# .NET 8 Web API with Entity Framework and Microsoft SQL Server, created as a basic sample template for creating simple RPG web APIs.

## Setup

1. Install Microsoft SQL Server of your choice.
2. Configure the connection string inside `appsettings.json` (and/or `appsettings.Development.json`) file.

Example `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SqlExpress; Database=dotnet-ef-api-rpg-game; Trusted_Connection=true; TrustServerCertificate=true;"
  }
}
```
For more information on connection strings, refer to the [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring?view=dotnet-plat-ext-8.0).
