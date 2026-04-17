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
    Blog? blog = _context.GetBlogByID(id);
    return blog is null ? NotFound() : Ok(blog);
  }

  [HttpGet]
  public IActionResult GetAllBlogs([FromQuery] string? term)
  {
    Blog[]? blogs = _context.GetAllBlogs(term);
    return blogs.Length == 0 ? NotFound() : Ok(blogs);
  }

  [HttpPost]
  public IActionResult PostBlog([FromBody] Blog blog)
  {
    _context.AddBlog(blog);
    return Created();
  }

  [HttpPut]
  public IActionResult PutBlog([FromBody] Blog blog)
  {
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteBlogByID(int id)
  {
    bool isDeleted = _context.DeleteBlog(id);
    return isDeleted ? NoContent() : NotFound();
  }
}