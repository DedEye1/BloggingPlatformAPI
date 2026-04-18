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
  public IActionResult GetBlogByID(int id)
  {
    Blog? blog = _context.ReadBlogByID(id);
    return blog is null ? NotFound() : Ok(blog);
  }

  [HttpGet]
  public IActionResult GetAllBlogs([FromQuery] string? term)
  {
    Blog[]? blogs = _context.ReadAllBlogs(term);
    return blogs.Length == 0 ? NotFound() : Ok(blogs);
  }

  [HttpPost]
  public IActionResult PostBlog([FromBody] Blog blog)
  {
    _context.CreateBlog(blog);
    return Created();
  }

  [HttpPut("{id}")]
  public IActionResult PutBlog(int id, [FromBody] Blog blog)
  {
    bool isUpdated = _context.UpdateBlog(id, blog);
    return isUpdated ? Ok() : NotFound();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteBlogByID(int id)
  {
    bool isDeleted = _context.DeleteBlog(id);
    return isDeleted ? NoContent() : NotFound();
  }
}