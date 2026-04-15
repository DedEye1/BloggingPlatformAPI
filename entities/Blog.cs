using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformAPI.entities;

[Table("Blogs")]
public class Blog(string title, string content, string category, string[] tags, DateTimeOffset? updatedAt)
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ID { get; init; }
  public string Title { get; set; } = title;
  public string Content { get; set; } = content;
  public string Category { get; set; } = category;
  public string[] Tags { get; set; } = tags;
  public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
  public DateTimeOffset? UpdatedAt { get; set; } = updatedAt;
}