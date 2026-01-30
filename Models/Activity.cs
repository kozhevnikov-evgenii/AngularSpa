namespace angularSPA.Models;

public class Activity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Company> Companies { get; set; } = new List<Company>();
}
