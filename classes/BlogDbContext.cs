using BloggingPlatformAPI.entities;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.classes;

public class BlogDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Blog> Blogs { get; set; }

  public Blog? GetBlogByID(int id) => Blogs.Find(id);

  public Blog[]? GetAllBlogs(string? term)
  {
    return Blogs.ToArray();
  }

  public void AddBlog(Blog blog)
  {
    Blogs.Add(blog);
    SaveChanges();
  }

  public bool DeleteBlog(int id)
  {
    Blog? blog = GetBlogByID(id);
    bool isDeleted = false;
    if (blog is not null)
    {
      Blogs.Remove(blog);
      SaveChanges();
      isDeleted = true;
    }
    return isDeleted;
  }
}