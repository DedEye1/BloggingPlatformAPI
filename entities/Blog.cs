namespace BloggingPlatformAPI.classes;

public class Blog(string title, string content, string category, string[] tags, DateTimeOffset? updatedAt)
{
  private static int _ID = 1;

  public int ID { get; } = _ID++;
  public string Title { get; set; } = title;
  public string Content { get; set; } = content;
  public string Category { get; set; } = category;
  public string[] Tags { get; set; } = tags;
  public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;
  public DateTimeOffset? UpdatedAt { get; set; } = updatedAt;
}