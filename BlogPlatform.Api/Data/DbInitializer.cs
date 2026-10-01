using BlogPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Api.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                BlogContext DbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

                await DbContext.Database.MigrateAsync(); // Apply any pending migrations to the database
                await SeedAsync(DbContext);
            }
        }

        private static async Task SeedAsync(BlogContext context)
        {
            if (await context.Posts.AnyAsync())
            {
                return; // Database has already been seeded or still has data, so we don't need to seed it again.
            }

            DateTime now = DateTime.UtcNow;

            List<Post> posts = new List<Post>
            {
                        new Post
        {
            Title = "Getting Started with ASP.NET Core",
            Content = "ASP.NET Core is a cross-platform framework for building web APIs and apps. In this post we set up a project, add a controller, and run our first endpoint.",
            Category = "Technology",
            Tags = new List<string> { "C#", "ASP.NET", "Backend" },
            CreatedAt = now.AddDays(-10),
            UpdatedAt = now.AddDays(-10)
        },
        new Post
        {
            Title = "Understanding REST Conventions",
            Content = "REST uses HTTP methods like GET, POST, PUT, and DELETE to model operations on resources. Good status codes and consistent URLs make an API easy to use.",
            Category = "Technology",
            Tags = new List<string> { "API", "REST", "HTTP" },
            CreatedAt = now.AddDays(-8),
            UpdatedAt = now.AddDays(-7)
        },
        new Post
        {
            Title = "Why Entity Framework Core Saves Time",
            Content = "EF Core maps your C# classes to database tables, handles migrations, and lets you query with LINQ instead of hand-written SQL.",
            Category = "Programming",
            Tags = new List<string> { "EF Core", "Database", "C#" },
            CreatedAt = now.AddDays(-6),
            UpdatedAt = now.AddDays(-6)
        },
        new Post
        {
            Title = "Five Habits of Productive Developers",
            Content = "Small habits compound: write things down, commit often, review your own code before asking others, take real breaks, and keep learning in small daily steps.",
            Category = "Career",
            Tags = new List<string> { "Productivity", "Career" },
            CreatedAt = now.AddDays(-4),
            UpdatedAt = now.AddDays(-3)
        },
        new Post
        {
            Title = "My Weekend Trip to the Coast",
            Content = "We packed light, took the early train, and spent two days walking along the beach, eating fresh fish, and not checking email once.",
            Category = "Travel",
            Tags = new List<string> { "Travel", "Weekend" },
            CreatedAt = now.AddDays(-2),
            UpdatedAt = now.AddDays(-2)
        },
        new Post
        {
            Title = "Simple Homemade Pasta",
            Content = "All you need is flour, eggs, and a pinch of salt. Knead for ten minutes, rest the dough, roll it thin, and cook for two minutes in boiling water.",
            Category = "Food",
            Tags = new List<string> { "Cooking", "Recipe", "Pasta" },
            CreatedAt = now.AddDays(-1),
            UpdatedAt = now.AddDays(-1)
        }
            };

            context.AddRange(posts);

            await context.SaveChangesAsync();
        }
    }
}
