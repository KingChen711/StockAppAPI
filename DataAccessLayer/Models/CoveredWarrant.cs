using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CoveredWarrant
{
    public int WarrantId { get; set; }

    public string Name { get; set; } = null!;

    public int? UnderlyingAssetId { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public decimal? StrikePrice { get; set; }

    public string? WarrantType { get; set; }

    public virtual Stock? UnderlyingAsset { get; set; }
}
