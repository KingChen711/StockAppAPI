using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Watchlist
{
    public int? UserId { get; set; }

    public int? StockId { get; set; }

    public virtual Stock? Stock { get; set; }

    public virtual User? User { get; set; }
}
