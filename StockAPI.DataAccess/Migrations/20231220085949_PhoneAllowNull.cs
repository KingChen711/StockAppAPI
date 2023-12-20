using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PhoneAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "educational_resources",
                columns: table => new
                {
                    resource_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    date_published = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__educatio__4985FC73CC55BEDB", x => x.resource_id);
                });

            migrationBuilder.CreateTable(
                name: "etfs",
                columns: table => new
                {
                    etf_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    management_company = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inception_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__etfs__91787216A5A955AE", x => x.etf_id);
                });

            migrationBuilder.CreateTable(
                name: "market_indices",
                columns: table => new
                {
                    index_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__market_i__9D4F318753F99E4F", x => x.index_id);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    stock_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    market_cap = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sector = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    industry = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    sector_en = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    industry_en = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    stock_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    rank_source = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stocks__E8666862BD758105", x => x.stock_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hashed_password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    country = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__B9BE370FAC90BD1D", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "etf_quotes",
                columns: table => new
                {
                    quote_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etf_id = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percent_change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_volume = table.Column<int>(type: "int", nullable: false),
                    time_stamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__etf_quot__0D37DF0CEBFE29CC", x => x.quote_id);
                    table.ForeignKey(
                        name: "FK__etf_quote__etf_i__5441852A",
                        column: x => x.etf_id,
                        principalTable: "etfs",
                        principalColumn: "etf_id");
                });

            migrationBuilder.CreateTable(
                name: "covered_warrants",
                columns: table => new
                {
                    warrant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    underlying_asset_id = table.Column<int>(type: "int", nullable: true),
                    issue_date = table.Column<DateOnly>(type: "date", nullable: true),
                    expiration_date = table.Column<DateOnly>(type: "date", nullable: true),
                    strike_price = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    warrant_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__covered___2BD1EED26456E8BF", x => x.warrant_id);
                    table.ForeignKey(
                        name: "FK__covered_w__under__4D94879B",
                        column: x => x.underlying_asset_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "derivatives",
                columns: table => new
                {
                    derivative_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    underlying_asset_id = table.Column<int>(type: "int", nullable: true),
                    contract_size = table.Column<int>(type: "int", nullable: true),
                    expiration_date = table.Column<DateOnly>(type: "date", nullable: true),
                    strike_price = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    last_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percent_change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    open_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    high_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    low_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    volume = table.Column<int>(type: "int", nullable: false),
                    open_interest = table.Column<int>(type: "int", nullable: false),
                    time_stamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__derivati__EF7FE46F6D870ABD", x => x.derivative_id);
                    table.ForeignKey(
                        name: "FK__derivativ__under__4AB81AF0",
                        column: x => x.underlying_asset_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "etf_holdings",
                columns: table => new
                {
                    etf_id = table.Column<int>(type: "int", nullable: true),
                    stock_id = table.Column<int>(type: "int", nullable: true),
                    shares_held = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__etf_holdi__etf_i__5629CD9C",
                        column: x => x.etf_id,
                        principalTable: "etfs",
                        principalColumn: "etf_id");
                    table.ForeignKey(
                        name: "FK__etf_holdi__stock__571DF1D5",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "index_constituents",
                columns: table => new
                {
                    index_id = table.Column<int>(type: "int", nullable: true),
                    stock_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__index_con__index__46E78A0C",
                        column: x => x.index_id,
                        principalTable: "market_indices",
                        principalColumn: "index_id");
                    table.ForeignKey(
                        name: "FK__index_con__stock__47DBAE45",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    quote_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stock_id = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percent_change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    volume = table.Column<int>(type: "int", nullable: false),
                    time_stamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__quotes__0D37DF0C6AAEF459", x => x.quote_id);
                    table.ForeignKey(
                        name: "FK__quotes__stock_id__4222D4EF",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "linked_bank_accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    bank_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    account_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    routing_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    account_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__linked_b__46A222CD40BA528E", x => x.account_id);
                    table.ForeignKey(
                        name: "FK__linked_ba__user___6A30C649",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    notification_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    is_read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifica__E059842F7DFE87E1", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK__notificat__user___6477ECF3",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    stock_id = table.Column<int>(type: "int", nullable: true),
                    order_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    direction = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__4659622963A55D9C", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__orders__stock_id__5EBF139D",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                    table.ForeignKey(
                        name: "FK__orders__user_id__5DCAEF64",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "portfolios",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: true),
                    stock_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    purchase_price = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    purchase_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Portfolios_Stocks",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                    table.ForeignKey(
                        name: "FK__portfolio__user___60A75C0F",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "user_devices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_dev__3213E83F4E8AB796", x => x.id);
                    table.ForeignKey(
                        name: "FK__user_devi__user___3B75D760",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: true),
                    stock_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__watchlist__stock__59FA5E80",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                    table.ForeignKey(
                        name: "FK__watchlist__user___59063A47",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    linked_account_id = table.Column<int>(type: "int", nullable: true),
                    transaction_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    transaction_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__transact__85C600AF8BFF503E", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK__transacti__linke__6E01572D",
                        column: x => x.linked_account_id,
                        principalTable: "linked_bank_accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK__transacti__user___6D0D32F4",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_covered_warrants_underlying_asset_id",
                table: "covered_warrants",
                column: "underlying_asset_id");

            migrationBuilder.CreateIndex(
                name: "IX_derivatives_underlying_asset_id",
                table: "derivatives",
                column: "underlying_asset_id");

            migrationBuilder.CreateIndex(
                name: "IX_etf_holdings_etf_id",
                table: "etf_holdings",
                column: "etf_id");

            migrationBuilder.CreateIndex(
                name: "IX_etf_holdings_stock_id",
                table: "etf_holdings",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_etf_quotes_etf_id",
                table: "etf_quotes",
                column: "etf_id");

            migrationBuilder.CreateIndex(
                name: "UQ__etfs__DF7EEB810D0E8CCD",
                table: "etfs",
                column: "symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_index_constituents_index_id",
                table: "index_constituents",
                column: "index_id");

            migrationBuilder.CreateIndex(
                name: "IX_index_constituents_stock_id",
                table: "index_constituents",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_linked_bank_accounts_user_id",
                table: "linked_bank_accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__market_i__DF7EEB8132E15D31",
                table: "market_indices",
                column: "symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_stock_id",
                table: "orders",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_stock_id",
                table: "portfolios",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_user_id",
                table: "portfolios",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_stock_id",
                table: "quotes",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "UQ__stocks__DF7EEB816AF5B9F2",
                table: "stocks",
                column: "symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_linked_account_id",
                table: "transactions",
                column: "linked_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_devices_user_id",
                table: "user_devices",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E61649A910B24",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__users__F3DBC57282BE2C7F",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_watchlists_stock_id",
                table: "watchlists",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "unique_WatchlistEntry",
                table: "watchlists",
                columns: new[] { "user_id", "stock_id" },
                unique: true,
                filter: "[user_id] IS NOT NULL AND [stock_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "covered_warrants");

            migrationBuilder.DropTable(
                name: "derivatives");

            migrationBuilder.DropTable(
                name: "educational_resources");

            migrationBuilder.DropTable(
                name: "etf_holdings");

            migrationBuilder.DropTable(
                name: "etf_quotes");

            migrationBuilder.DropTable(
                name: "index_constituents");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "portfolios");

            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "user_devices");

            migrationBuilder.DropTable(
                name: "watchlists");

            migrationBuilder.DropTable(
                name: "etfs");

            migrationBuilder.DropTable(
                name: "market_indices");

            migrationBuilder.DropTable(
                name: "linked_bank_accounts");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
