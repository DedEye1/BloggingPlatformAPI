using BloggingPlatformAPI.entities;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.classes;

public class BlogDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Blog> Blogs { get; set; }

  public void CreateBlog(Blog blog)
  {
    Blogs.Add(blog);
    SaveChanges();
  }

  public Blog? ReadBlogByID(int id) => Blogs.Find(id);

  public Blog[] ReadAllBlogs(string? term)
  {
    Blog[] result = Blogs.OrderBy(b => b.ID).ToArray();
    if (term is not null)
    {
      result = Blogs.Where(b => b.Tags.Contains(term)).ToArray();
    }
    return result;
  }

  public bool UpdateBlog(int id, Blog updatedBlog)
  {
    bool isUpdated = false;
    Blog? blog = ReadBlogByID(id);
    if (blog is not null)
    {
      blog.Title = updatedBlog.Title;
      blog.Content = updatedBlog.Content;
      blog.Category = updatedBlog.Category;
      blog.Tags = updatedBlog.Tags;
      blog.UpdatedAt = DateTimeOffset.UtcNow;
      SaveChanges();
      isUpdated = true;
    }
    return isUpdated;
  }

  public bool DeleteBlog(int id)
  {
    bool isDeleted = false;
    Blog? blog = ReadBlogByID(id);
    if (blog is not null)
    {
      Blogs.Remove(blog);
      SaveChanges();
      isDeleted = true;
    }
    return isDeleted;
  }
}