# EasySun - ASP.NET Core RESTful Service

[![telegram chat](https://img.shields.io/badge/Developer-Telegram-blue.svg?style=flat-square)](https://t.me/SystemNick)

**EasySun** is implementation of ASP.NET Core RESTful API project with latest Web API & EF Core technologies.

This application uses <https://sunrise-sunset.org/api> to get sunrise and sunset timings based on requested city.

## Getting Started

Use these instructions to get the project up and running.

### Prerequisites

You will need the following tools:

- [Visual Studio 2019]
- [.NET 5 or later]
- EF Core 5.x or later

### Installing

Follow these steps to get your development environment set up:

1. Clone the repository
2. At the root directory, restore required packages by running:

``` Power Shell
dotnet restore
```

3. Next, build the solution by running:

``` Power Shell
dotnet build
```

4. Next, within the EasySun project directory, launch the app by running:

``` Power Shell
dotnet run
```

5. Launch <http://localhost:44323/swagger/> in your browser to try out the API calls right there.

If you have Visual Studio after cloning Open solution with your IDE, EasySun should be the start-up project. Directly run this project on Visual Studio with F5 or Ctrl+F5. You will see swagger page, you can check API methods and you can perform crud operations on your browser.

### Usage

After cloning or downloading the sample you should be able to run it using a persistent database immediately. The project configuration of Entity Framework Database is set to **"SQL Server"**.

#### SQL Server (default)

If you wish to use the project with a persistent database, you will need to run project's Entity Framework Core migrations before you will be able to run the app (see below).

1. Ensure your connection strings in appsettings.json point to a local SQL Server instance.

2. Open a command prompt in the project folder and execute the following commands:

``` PowerShell
dotnet restore
dotnet ef database update
```

These commands will create EasySunDB database which includes Countries, Cities and EventTimes tables.

Run the application. The first time you run the application, it will seed EasySunDB sql server database with a few data such that you should already have some cities and countries.

If you modify-change or add new entities to the project, you should run EF migrate commands in order to update your database as the same way but below commands:

``` PowerShell
add migration YourCustomEntityChanges
update-database
```

#### In Memory database

If you wish to use the project with an In Memory database for testing purposes, you will need to update the ConfigureDatabases method in Startup.cs (see below).

``` C#
public void ConfigureDatabases(IServiceCollection services)
{
    services.AddDbContext<SunDbContext>(optionsAction =>
        optionsAction.UseInMemoryDatabase("EasySunDB")); // in-memory
        // optionsAction.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); // real
}
```

## Managing EF Core Migrations

_This section is optional and shouldn't be followed if the project runs fine._

**If** you loose the migration files from /Migrations/ directiry (thus app can't create the database) EF Core can generate them from existing Models again. Open command prompt, navigate to project directory and execute the following commands.

``` PowerShell
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

_More details about migrations on [the official docs]._

## Technologies

- ASP.NET Core 5.x
- Entity Framework Core 5.x
- SunriseSunsetClient 1.x

## Architecture

- Clean Architecture
- Full architecture with responsibility separation of concerns
- SOLID and Clean Cod
- RESTful API Service

## Disclaimer

- This repository is not intended to be a definitive solution.
- This repository not implemented a lot of 3rd party packages, I try to avoid the over engineering when building on best practices.
- Beware to use in production way.

## License

This project is licensed under the MIT License - see the [LICENSE] file for details.

[original website]: https://sunrise-sunset.org
[Visual Studio 2019]: https://visualstudio.microsoft.com/downloads/
[.NET 5 or later]: https://dotnet.microsoft.com/download/dotnet-core
[the official docs]: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations
[LICENSE]: https://github.com/SystemNickV/EasySun/blob/master/LICENSE
