using BlogPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Api.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts = null!;
    }
}
