using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAPI.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("username")]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    [Column("hashed_password")]
    public string HashedPassword { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    [Column("email")]
    public string Email { get; set; } = null!;

    [MaxLength(20)]
    [Column("phone")]
    public string? Phone { get; set; }

    [MaxLength(255)]
    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [MaxLength(200)]
    [Column("country")]
    public string? Country { get; set; }

    [InverseProperty(nameof(LinkedBankAccount.User))]
    public virtual ICollection<LinkedBankAccount> LinkedBankAccounts { get; set; } = new List<LinkedBankAccount>();

    [InverseProperty(nameof(Notification.User))]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty(nameof(Order.User))]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty(nameof(Transaction.User))]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty(nameof(UserDevice.User))]
    public virtual ICollection<UserDevice> UserDevices { get; set; } = new List<UserDevice>();
}
