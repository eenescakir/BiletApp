# BiletApp – Ticket Sales Application

BiletApp is a modern ticket sales application developed using ASP.NET Core MVC, Entity Framework Core, and SQLite.

Quick Start

To run the project, see the SETUP.md file.

Quick setup:
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run

Open in browser:
http://localhost:5000

Features

- Normalized database with 4 tables: Category, Event, Ticket, Order
- One-to-many relationships between entities
- Full CRUD operations for all entities
- ViewModel usage
- Dropdown selections for relations
- Image upload support
- Modern UI with Bootstrap 5
- Clean code principles

Technologies

- ASP.NET Core MVC 10.0
- Entity Framework Core 8.0
- SQLite
- Bootstrap 5
- jQuery
- Font Awesome

Database Structure

Category, Event, Ticket, Order tables with proper relations.

Usage

- Manage categories
- Manage events
- Manage tickets
- Manage orders

License

Educational purpose only.
