# CleanArchitectureSample
This is a solution template for Clean Architecture implementation with .NET Core and overview.


 
Architecture importance:

Software architecture is the high level structure of a software system, the discipline of creating such structures, and the documentation of these structures.
It is the set of structures needed to reason about the software system, and comprises the software elements, the relations between them, and the properties of both elements and relations.
In today’s software development world, requirements change, environments change, team members change, technologies change, and so should the architecture of our systems.
The architecture defines the parts of a system that are hard and costly to change. Therefore we are in need of a clean, simple, flexible, evolvable, and agile architecture to be able to keep up with all the changes surrounding us.

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebApi

This layer is a web api application based on ASP.NET 6.0.x. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

### Logs

Logging into Elasticsearch using Serilog and viewing logs in Kibana.


Testable:

The business rules and use cases can be tested without UI, database, Web server, or any other external element.

This is a solution template for creating a ASP.NET Core Web API following the principles of Clean Architecture. Create a new project based on this template by clicking the above **Use this template** button or by installing and running the associated NuGet package (see Getting Started for full details). 


## Technologies
* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [Mapster](https://github.com/MapsterMapper/Mapster)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/), [Moq](https://github.com/moq) & [Respawn](https://github.com/jbogard/Respawn)
* [Elasticsearch](https://www.elastic.co/), [Serilog](https://serilog.net/), [Kibana](https://www.elastic.co/kibana)
* [Docker](https://www.docker.com/)



# Software Development Best Practices and Design Principles used:
Clean Architecture
Clean Code
CQRS
Authentication and Authorization
Distributed caching
Solid Principles
Separate ReadOnly and Write DbContext
Separate ReadOnly and Write Repository
REST API Naming Conventions
Use multiple environments in ASP.NET Core (Development,Production,Staging)
Modular Design
Custom Exceptions
Custom Exception Handling
PipelineBehavior for Validation and Performance tracking.



### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebApi/appsettings.json** as follows:

```json
  "DbProvider": SqlServer
```

`DbProvider` could be `Sqlite`, `SqlServer`, `Npgsql` by default, which could be extended to more database providers that EF Core supports. 

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance.

Verify that the **DefaultConnection_Postgres** connection string within **appsettings.json** points to a valid PostgresSQL instance.

Verify that the **DefaultConnection_Sqlite** connection string within **appsettings.json** points to a valid Sqlite connection or in-memory instance.

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.


### Database Migrations

By moving to multiple databases migrations, every db provider will have one migrations project as below.

* `Sqlite`: CleanArchitecture.Infrastructure.Sqlite
* `SqlServer`: CleanArchitecture.Infrastructure.SqlServer
* `Npgsql`: CleanArchitecture.Infrastructure.Npgsql



