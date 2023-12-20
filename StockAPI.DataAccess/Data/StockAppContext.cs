using Microsoft.EntityFrameworkCore;
using StockAPI.Models;

namespace StockAPI.DataAccess.Data;

public partial class StockAppContext : DbContext
{
    public StockAppContext(DbContextOptions<StockAppContext> options) : base(options)
    {
    }

    public virtual DbSet<CoveredWarrant> CoveredWarrants { get; set; }

    public virtual DbSet<Derivative> Derivatives { get; set; }

    public virtual DbSet<EducationalResource> EducationalResources { get; set; }

    public virtual DbSet<Etf> Etfs { get; set; }

    public virtual DbSet<EtfHolding> EtfHoldings { get; set; }

    public virtual DbSet<EtfQuote> EtfQuotes { get; set; }

    public virtual DbSet<IndexConstituent> IndexConstituents { get; set; }

    public virtual DbSet<LinkedBankAccount> LinkedBankAccounts { get; set; }

    public virtual DbSet<MarketIndex> MarketIndices { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDevice> UserDevices { get; set; }

    public virtual DbSet<VStockIndex> VStockIndices { get; set; }

    public virtual DbSet<VStocksDerivative> VStocksDerivatives { get; set; }

    public virtual DbSet<ViewQuotesRealtime> ViewQuotesRealtimes { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoveredWarrant>(entity =>
        {
            entity.HasKey(e => e.WarrantId).HasName("PK__covered___2BD1EED26456E8BF");

            entity.ToTable("covered_warrants");

            entity.Property(e => e.WarrantId).HasColumnName("warrant_id");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StrikePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("strike_price");
            entity.Property(e => e.UnderlyingAssetId).HasColumnName("underlying_asset_id");
            entity.Property(e => e.WarrantType)
                .HasMaxLength(50)
                .HasColumnName("warrant_type");

            entity.HasOne(d => d.UnderlyingAsset).WithMany(p => p.CoveredWarrants)
                .HasForeignKey(d => d.UnderlyingAssetId)
                .HasConstraintName("FK__covered_w__under__4D94879B");
        });

        modelBuilder.Entity<Derivative>(entity =>
        {
            entity.HasKey(e => e.DerivativeId).HasName("PK__derivati__EF7FE46F6D870ABD");

            entity.ToTable("derivatives");

            entity.Property(e => e.DerivativeId).HasColumnName("derivative_id");
            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.ContractSize).HasColumnName("contract_size");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.HighPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("high_price");
            entity.Property(e => e.LastPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("last_price");
            entity.Property(e => e.LowPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("low_price");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OpenInterest).HasColumnName("open_interest");
            entity.Property(e => e.OpenPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("open_price");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.StrikePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("strike_price");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.UnderlyingAssetId).HasColumnName("underlying_asset_id");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.UnderlyingAsset).WithMany(p => p.Derivatives)
                .HasForeignKey(d => d.UnderlyingAssetId)
                .HasConstraintName("FK__derivativ__under__4AB81AF0");
        });

        modelBuilder.Entity<EducationalResource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__educatio__4985FC73CC55BEDB");

            entity.ToTable("educational_resources");

            entity.Property(e => e.ResourceId).HasColumnName("resource_id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.DatePublished)
                .HasColumnType("datetime")
                .HasColumnName("date_published");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Etf>(entity =>
        {
            entity.HasKey(e => e.EtfId).HasName("PK__etfs__91787216A5A955AE");

            entity.ToTable("etfs");

            entity.HasIndex(e => e.Symbol, "UQ__etfs__DF7EEB810D0E8CCD").IsUnique();

            entity.Property(e => e.EtfId).HasColumnName("etf_id");
            entity.Property(e => e.InceptionDate).HasColumnName("inception_date");
            entity.Property(e => e.ManagementCompany)
                .HasMaxLength(255)
                .HasColumnName("management_company");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<EtfHolding>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("etf_holdings");

            entity.Property(e => e.EtfId).HasColumnName("etf_id");
            entity.Property(e => e.SharesHeld)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("shares_held");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Etf).WithMany()
                .HasForeignKey(d => d.EtfId)
                .HasConstraintName("FK__etf_holdi__etf_i__5629CD9C");

            entity.HasOne(d => d.Stock).WithMany()
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__etf_holdi__stock__571DF1D5");
        });

        modelBuilder.Entity<EtfQuote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__etf_quot__0D37DF0CEBFE29CC");

            entity.ToTable("etf_quotes");

            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.EtfId).HasColumnName("etf_id");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.TotalVolume).HasColumnName("total_volume");

            entity.HasOne(d => d.Etf).WithMany(p => p.EtfQuotes)
                .HasForeignKey(d => d.EtfId)
                .HasConstraintName("FK__etf_quote__etf_i__5441852A");
        });

        modelBuilder.Entity<IndexConstituent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("index_constituents");

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.StockId).HasColumnName("stock_id");

            entity.HasOne(d => d.Index).WithMany()
                .HasForeignKey(d => d.IndexId)
                .HasConstraintName("FK__index_con__index__46E78A0C");

            entity.HasOne(d => d.Stock).WithMany()
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__index_con__stock__47DBAE45");
        });

        modelBuilder.Entity<LinkedBankAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__linked_b__46A222CD40BA528E");

            entity.ToTable("linked_bank_accounts");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .HasColumnName("account_number");
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .HasColumnName("account_type");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .HasColumnName("bank_name");
            entity.Property(e => e.RoutingNumber)
                .HasMaxLength(50)
                .HasColumnName("routing_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LinkedBankAccounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__linked_ba__user___6A30C649");
        });

        modelBuilder.Entity<MarketIndex>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK__market_i__9D4F318753F99E4F");

            entity.ToTable("market_indices");

            entity.HasIndex(e => e.Symbol, "UQ__market_i__DF7EEB8132E15D31").IsUnique();

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842F7DFE87E1");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("notification_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__notificat__user___6477ECF3");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__4659622963A55D9C");

            entity.ToTable("orders", tb => tb.HasTrigger("trigger_orders"));

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Direction)
                .HasMaxLength(20)
                .HasColumnName("direction");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderType)
                .HasMaxLength(20)
                .HasColumnName("order_type");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Stock).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__orders__stock_id__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__orders__user_id__5DCAEF64");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("portfolios");

            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("purchase_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Stock).WithMany()
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK_Portfolios_Stocks");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__portfolio__user___60A75C0F");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__quotes__0D37DF0C6AAEF459");

            entity.ToTable("quotes");

            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.Stock).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__quotes__stock_id__4222D4EF");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__stocks__E8666862BD758105");

            entity.ToTable("stocks");

            entity.HasIndex(e => e.Symbol, "UQ__stocks__DF7EEB816AF5B9F2").IsUnique();

            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Industry)
                .HasMaxLength(200)
                .HasColumnName("industry");
            entity.Property(e => e.IndustryEn)
                .HasMaxLength(200)
                .HasColumnName("industry_en");
            entity.Property(e => e.MarketCap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("market_cap");
            entity.Property(e => e.Rank)
                .HasDefaultValue(0)
                .HasColumnName("rank");
            entity.Property(e => e.RankSource)
                .HasMaxLength(200)
                .HasColumnName("rank_source");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.Sector)
                .HasMaxLength(200)
                .HasColumnName("sector");
            entity.Property(e => e.SectorEn)
                .HasMaxLength(200)
                .HasColumnName("sector_en");
            entity.Property(e => e.StockType)
                .HasMaxLength(50)
                .HasColumnName("stock_type");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__transact__85C600AF8BFF503E");

            entity.ToTable("transactions");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.LinkedAccountId).HasColumnName("linked_account_id");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .HasColumnName("transaction_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.LinkedAccount).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.LinkedAccountId)
                .HasConstraintName("FK__transacti__linke__6E01572D");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__transacti__user___6D0D32F4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FAC90BD1D");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61649A910B24").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC57282BE2C7F").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .HasColumnName("country");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(200)
                .HasColumnName("hashed_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });


        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_dev__3213E83F4E8AB796");

            entity.ToTable("user_devices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(255)
                .HasColumnName("device_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserDevices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_devi__user___3B75D760");
        });

        modelBuilder.Entity<VStockIndex>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_stock_index");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.IndexName)
                .HasMaxLength(255)
                .HasColumnName("index_name");
            entity.Property(e => e.IndexSymbol)
                .HasMaxLength(50)
                .HasColumnName("index_symbol");
            entity.Property(e => e.Industry)
                .HasMaxLength(200)
                .HasColumnName("industry");
            entity.Property(e => e.IndustryEn)
                .HasMaxLength(200)
                .HasColumnName("industry_en");
            entity.Property(e => e.MarketCap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("market_cap");
            entity.Property(e => e.Sector)
                .HasMaxLength(200)
                .HasColumnName("sector");
            entity.Property(e => e.SectorEn)
                .HasMaxLength(200)
                .HasColumnName("sector_en");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.StockType)
                .HasMaxLength(50)
                .HasColumnName("stock_type");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<VStocksDerivative>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_stocks_derivatives");

            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.ContractSize).HasColumnName("contract_size");
            entity.Property(e => e.DerivativeId).HasColumnName("derivative_id");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.HighPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("high_price");
            entity.Property(e => e.Industry)
                .HasMaxLength(200)
                .HasColumnName("industry");
            entity.Property(e => e.IndustryEn)
                .HasMaxLength(200)
                .HasColumnName("industry_en");
            entity.Property(e => e.LastPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("last_price");
            entity.Property(e => e.LowPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("low_price");
            entity.Property(e => e.MarketCap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("market_cap");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OpenInterest).HasColumnName("open_interest");
            entity.Property(e => e.OpenPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("open_price");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.RankSource)
                .HasMaxLength(200)
                .HasColumnName("rank_source");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.Sector)
                .HasMaxLength(200)
                .HasColumnName("sector");
            entity.Property(e => e.SectorEn)
                .HasMaxLength(200)
                .HasColumnName("sector_en");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.StockType)
                .HasMaxLength(50)
                .HasColumnName("stock_type");
            entity.Property(e => e.StrikePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("strike_price");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.UnderlyingAssetId).HasColumnName("underlying_asset_id");
            entity.Property(e => e.Volume).HasColumnName("volume");
        });

        modelBuilder.Entity<ViewQuotesRealtime>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_quotes_realtime");

            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.IndexName)
                .HasMaxLength(255)
                .HasColumnName("index_name");
            entity.Property(e => e.IndexSymbol)
                .HasMaxLength(50)
                .HasColumnName("index_symbol");
            entity.Property(e => e.Industry)
                .HasMaxLength(200)
                .HasColumnName("industry");
            entity.Property(e => e.IndustryEn)
                .HasMaxLength(200)
                .HasColumnName("industry_en");
            entity.Property(e => e.MarketCap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("market_cap");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.Sector)
                .HasMaxLength(200)
                .HasColumnName("sector");
            entity.Property(e => e.SectorEn)
                .HasMaxLength(200)
                .HasColumnName("sector_en");
            entity.Property(e => e.StockType)
                .HasMaxLength(50)
                .HasColumnName("stock_type");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Volume).HasColumnName("volume");
        });

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("watchlists");

            entity.HasIndex(e => new { e.UserId, e.StockId }, "unique_WatchlistEntry").IsUnique();

            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Stock).WithMany()
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__watchlist__stock__59FA5E80");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__watchlist__user___59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
