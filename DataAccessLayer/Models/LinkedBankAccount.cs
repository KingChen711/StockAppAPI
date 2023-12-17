using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class LinkedBankAccount
{
    public int AccountId { get; set; }

    public int? UserId { get; set; }

    public string BankName { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string? RoutingNumber { get; set; }

    public string? AccountType { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
