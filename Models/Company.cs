namespace AngularSPA.Models;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ActivityId { get; set; }

    public Activity Activity { get; set; } = null!;
}
