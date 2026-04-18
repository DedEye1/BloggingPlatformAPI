using BloggingPlatformAPI.classes;
using BloggingPlatformAPI.entities;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.controllers;

[ApiController]
[Route("/posts", Name = nameof(HandleBlogs))]
public class HandleBlogs(BlogDbContext context) : ControllerBase
{
  private readonly BlogDbContext _context = context;

  [HttpGet("{id}")]
  public async Task<IActionResult> GetBlogByID(int id)
  {
    Blog? blog = await _context.ReadBlogByIDAsync(id);
    return blog is null ? NotFound() : Ok(blog);
  }

  [HttpGet]
  public async Task<IActionResult> GetAllBlogs([FromQuery] string? term)
  {
    Blog[]? blogs = await _context.ReadAllBlogsAsync(term);
    return blogs.Length == 0 ? NotFound() : Ok(blogs);
  }

  [HttpPost]
  public async Task<IActionResult> PostBlog([FromBody] Blog blog)
  {
    await _context.CreateBlogAsync(blog);
    return Created();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutBlog(int id, [FromBody] Blog blog)
  {
    bool isUpdated = await _context.UpdateBlogAsync(id, blog);
    return isUpdated ? Ok() : NotFound();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBlogByID(int id)
  {
    bool isDeleted = await _context.DeleteBlogAsync(id);
    return isDeleted ? NoContent() : NotFound();
  }
}