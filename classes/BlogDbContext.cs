using BloggingPlatformAPI.entities;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.classes;

public class BlogDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Blog> Blogs { get; set; }

  public async Task CreateBlogAsync(Blog blog)
  {
    Blogs.Add(blog);
    await SaveChangesAsync();
  }

  public async Task<Blog?> ReadBlogByIDAsync(int id) => await Blogs.FindAsync(id);

  public async Task<Blog[]> ReadAllBlogsAsync(string? term)
  {
    Blog[] result = await Blogs.OrderBy(b => b.ID).ToArrayAsync();
    if (term is not null)
    {
      result = result.Where(b => b.Tags.Contains(term)).ToArray();
    }
    return result;
  }

  public async Task<bool> UpdateBlogAsync(int id, Blog updatedBlog)
  {
    bool isUpdated = false;
    Blog? blog = await ReadBlogByIDAsync(id);
    if (blog is not null)
    {
      if (!string.IsNullOrEmpty(updatedBlog.Title))
        blog.Title = updatedBlog.Title;
      if (!string.IsNullOrEmpty(updatedBlog.Content))
        blog.Content = updatedBlog.Content;
      if (!string.IsNullOrEmpty(updatedBlog.Category))
        blog.Category = updatedBlog.Category;
      if (updatedBlog.Tags is not null && updatedBlog.Tags.Length != 0)
        blog.Tags = updatedBlog.Tags;
      blog.UpdatedAt = DateTimeOffset.UtcNow;
      await SaveChangesAsync();
      isUpdated = true;
    }
    return isUpdated;
  }

  public async Task<bool> DeleteBlogAsync(int id)
  {
    bool isDeleted = false;
    Blog? blog = await ReadBlogByIDAsync(id);
    if (blog is not null)
    {
      Blogs.Remove(blog);
      await SaveChangesAsync();
      isDeleted = true;
    }
    return isDeleted;
  }
}