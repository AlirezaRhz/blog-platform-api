# Blogging Platform API

A simple RESTful API for a personal blogging platform, built with ASP.NET Core and Entity Framework Core. It supports basic CRUD operations on blog posts, plus searching by a term.

This project is based on the [Blogging Platform API](https://roadmap.sh/projects/blogging-platform-api) challenge from roadmap.sh.

## Features

- Create, read, update, and delete blog posts
- Search posts by a term (matches title, content, or category, case-insensitive)
- Request validation with `400 Bad Request` error responses
- Proper status codes (`201`, `200`, `204`, `400`, `404`)
- Automatic migrations and sample data seeding on startup

## Tech Stack

- C# / ASP.NET Core Web API
- Entity Framework Core
- Database: sqlite

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version matching the project)
- The database you configured, if it needs a separate server

### Setup

1. Clone the repository:

   ```bash
   git clone <your-repo-url>
   cd <your-project-folder>
   ```

2. Set your database connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "<your connection string>"
   }
   ```

3. Run the app:

   ```bash
   dotnet run
   ```

On startup the app applies any pending migrations and seeds six sample posts if the database is empty, so there is no manual `dotnet ef database update` step.
