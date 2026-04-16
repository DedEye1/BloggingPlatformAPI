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
    IActionResult result;
    Blog? blog = _context.GetBlogByID(id);

    if (blog is null) result = NotFound();
    else result = Ok(blog);

    return result;
  }

  [HttpGet]
  public IActionResult GetAllBlogs([FromQuery] string? term)
  {
    IActionResult result;
    Blog[]? blogs = _context.GetAllBlogs(term);

    if (blogs is null) result = NotFound();
    else result = Ok(blogs);

    return result;
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
    IActionResult result;
    bool isDeleted = _context.DeleteBlog(id);

    if (isDeleted) result = NoContent();
    else result = NotFound();

    return result;
  }
}