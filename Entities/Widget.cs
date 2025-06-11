namespace VersioningDemo.Entities;

public class Widget
{
    public Guid Id { get; set; }
    public string Color { get; set; }
    public string Dimensions { get; set; }
    public string Shape { get; set; }
    public bool IsActive { get; set; } = true;
}