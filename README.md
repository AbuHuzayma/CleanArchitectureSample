# CleanArchitectureSample
This is a solution template for Clean Architecture implementation with .NET Core and overview.
 
Architecture importance:

Software architecture is the high level structure of a software system, the discipline of creating such structures, and the documentation of these structures.
It is the set of structures needed to reason about the software system, and comprises the software elements, the relations between them, and the properties of both elements and relations.
In today’s software development world, requirements change, environments change, team members change, technologies change, and so should the architecture of our systems.
The architecture defines the parts of a system that are hard and costly to change. Therefore we are in need of a clean, simple, flexible, evolvable, and agile architecture to be able to keep up with all the changes surrounding us.

Clean architecture:

Entities: Entities encapsulate enterprise-wide business rules. An entity can be an object with methods, or it can be a set of data structures and functions.
Use cases: Use cases orchestrate the flow of data to and from the entities, and direct those entities to use their enterprise-wide business rules to achieve the goals of the use cases.
Interface adapters: Adapters that convert data from the format most convenient for the use cases and entities, to the format most convenient for some external agency such as a database or the Web.
Frameworks and drivers: Glue code to connect UI, databases, devices etc. to the inner circles.
Program Flow: Starts on the outside and ends on the outside, but can go through several layers (user clicks a button, use case loads some entities from DB, entities decide something that is presented on the UI)
Dependency management:
The concentric circles represent different areas of software. In general, the further in you go, the higher level the software becomes. The outer circles are mechanisms. The inner circles are policies.
Source code dependencies can only point inwards. Nothing in an inner circle can know anything at all about something in an outer circle. Use dependency inversion to build up the system (classes in an outer circle implement interfaces of an inner circle or listen to events from inner circles).
Independent of frameworks:
The architecture does not depend on the existence of some library of feature-laden software. This allows you to use such frameworks as tools, rather than having to cram your system into their technical constraints.

Testable:

The business rules and use cases can be tested without UI, database, Web server, or any other external element.

# Technologies used:
ASP.NET Core
Entity Framework Core
MediatR
Swagger
Jwt Token Authentication
Api Versioning
FluentValidation
Serilog
AutoMapper


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

