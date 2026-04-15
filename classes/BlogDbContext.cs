using BloggingPlatformAPI.entities;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.classes;

#nullable disable
public class BlogDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Blog> Blogs { get; set; }
}