using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Portfolio
{
    public int? UserId { get; set; }

    public int? StockId { get; set; }

    public int? Quantity { get; set; }

    public decimal? PurchasePrice { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public virtual Stock? Stock { get; set; }

    public virtual User? User { get; set; }
}
