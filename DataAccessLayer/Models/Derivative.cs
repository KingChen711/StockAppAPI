using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Derivative
{
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

    public virtual Stock? UnderlyingAsset { get; set; }
}
