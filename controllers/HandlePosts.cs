using BloggingPlatformAPI.classes;
using BloggingPlatformAPI.entities;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.controllers;

[ApiController]
[Route("/posts", Name = "HandlePosts")]
public class HandlePosts(BlogDbContext context) : ControllerBase
{
  private readonly BlogDbContext _context = context;

  [HttpGet("{id}")]
  public IActionResult GetBlogsByID(int id, [FromQuery] string term)
  {
    return Ok(_context.Database.CanConnect());
  }

  [HttpGet]
  public IActionResult GetAllBlogs([FromQuery] string term)
  {
    return Ok();
  }

  [HttpPost]
  public IActionResult PostBlog([FromBody] Blog blog)
  {
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
    return NoContent();
  }
}