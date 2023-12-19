namespace StockAPI.Models;

public partial class MarketIndex
{
    public int IndexId { get; set; }

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;
}
