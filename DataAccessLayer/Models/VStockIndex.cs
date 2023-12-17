using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class VStockIndex
{
    public int StockId { get; set; }

    public string Symbol { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public decimal? MarketCap { get; set; }

    public string? SectorEn { get; set; }

    public string? Sector { get; set; }

    public string? IndustryEn { get; set; }

    public string? Industry { get; set; }

    public string? StockType { get; set; }

    public int? IndexId { get; set; }

    public string IndexSymbol { get; set; } = null!;

    public string IndexName { get; set; } = null!;
}
