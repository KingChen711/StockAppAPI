﻿namespace StockAPI.Models;

public partial class Etf
{
    public int EtfId { get; set; }

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string? ManagementCompany { get; set; }

    public DateOnly? InceptionDate { get; set; }

    public virtual ICollection<EtfQuote> EtfQuotes { get; set; } = new List<EtfQuote>();
}
