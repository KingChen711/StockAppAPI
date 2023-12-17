using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class VStocksDerivative
{
    public int StockId { get; set; }

    public string Symbol { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public decimal? MarketCap { get; set; }

    public string? Sector { get; set; }

    public string? Industry { get; set; }

    public string? SectorEn { get; set; }

    public string? IndustryEn { get; set; }

    public string? StockType { get; set; }

    public int? Rank { get; set; }

    public string? RankSource { get; set; }

    public string? Reason { get; set; }

    public int DerivativeId { get; set; }

    public string Name { get; set; } = null!;

    public int? UnderlyingAssetId { get; set; }

    public int? ContractSize { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public decimal? StrikePrice { get; set; }

    public decimal LastPrice { get; set; }

    public decimal Change { get; set; }

    public decimal PercentChange { get; set; }

    public decimal OpenPrice { get; set; }

    public decimal HighPrice { get; set; }

    public decimal LowPrice { get; set; }

    public int Volume { get; set; }

    public int OpenInterest { get; set; }

    public DateTime TimeStamp { get; set; }
}
