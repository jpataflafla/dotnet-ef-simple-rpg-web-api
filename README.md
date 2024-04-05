# .NET 8 Web API with Entity Framework and Microsoft SQL Server, created as a basic sample template for creating simple RPG web APIs.

## Setup

1. Install Microsoft SQL Server of your choice.
2. Configure the connection string inside `appsettings.json` (and/or `appsettings.Development.json`) file.

    Example of a connection string inside `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=.\\SqlExpress; Database=dotnet-ef-api-rpg-game; Trusted_Connection=true; TrustServerCertificate=true;"
      }
    }
    ```
    For more information on connection strings, refer to the [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring?view=dotnet-plat-ext-8.0).

3. Install `dotnet-ef` tool if it is not already installed:  
   [dotnet-ef nuget](https://www.nuget.org/packages/dotnet-ef)
   ```sh
   dotnet tool install --global dotnet-ef
   ```
    For more information on Entity Framework tools, please refer to the [Microsoft documentation](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
   
5. Then to create and update DB, apply migrations:
   ```sh
   dotnet ef database update
   ```

## more in progress..
