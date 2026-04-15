using BloggingPlatformAPI.classes;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.controllers;

[ApiController]
[Route("/posts", Name = "HandlePosts")]
public class HandlePosts : ControllerBase
{
  [HttpGet("{id}")]
  public IActionResult GetPostsByID(int id, [FromQuery] string term)
  {
    return Ok();
  }

  [HttpGet]
  public IActionResult GetAllPosts([FromQuery] string term)
  {
    return Ok();
  }

  [HttpPost]
  public IActionResult CreatePost([FromBody] Blog blog)
  {
    return Created();
  }

  [HttpPut]
  public IActionResult UpdatePost([FromBody] Blog blog)
  {
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult DeletePostByID(int id)
  {
    return NoContent();
  }
}