namespace StockAPI.Models;

public partial class EducationalResource
{
    public int ResourceId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Category { get; set; }

    public DateTime? DatePublished { get; set; }
}
