using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebAPI.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class order_item_book_duplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Giftcard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giftcard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsBanned = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverImageName = table.Column<string>(type: "TEXT", nullable: true),
                    EditCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LastEditedById = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_User_LastEditedById",
                        column: x => x.LastEditedById,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReview_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReview_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiftcardCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GiftcardId = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftcardCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftcardCode_Giftcard_GiftcardId",
                        column: x => x.GiftcardId,
                        principalTable: "Giftcard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GiftcardCodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_GiftcardCode_GiftcardCodeId",
                        column: x => x.GiftcardCodeId,
                        principalTable: "GiftcardCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookTitle = table.Column<string>(type: "TEXT", nullable: false),
                    BookISBN = table.Column<string>(type: "TEXT", nullable: false),
                    BookPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    BookPublisher = table.Column<string>(type: "TEXT", nullable: false),
                    BookAuthor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Theodore", "Ruecker" },
                    { 2, "Marcelina", "Swift" },
                    { 3, "Harley", "Predovic" },
                    { 4, "Miguel", "Spencer" },
                    { 5, "Amos", "Heidenreich" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Horror" },
                    { 3, "Science Fiction" },
                    { 4, "Romance" },
                    { 5, "Thriller" },
                    { 6, "Mystery" },
                    { 7, "Biography" },
                    { 8, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Giftcard",
                columns: new[] { "Id", "Amount", "Name", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 1000m, "Awesome Steel Computer", new DateTime(2023, 4, 30, 14, 11, 54, 542, DateTimeKind.Unspecified).AddTicks(6302), new DateTime(2023, 10, 30, 14, 11, 54, 542, DateTimeKind.Unspecified).AddTicks(6302) },
                    { 2, 1000m, "Tasty Wooden Keyboard", new DateTime(2025, 5, 2, 23, 3, 10, 924, DateTimeKind.Unspecified).AddTicks(6255), new DateTime(2026, 2, 2, 23, 3, 10, 924, DateTimeKind.Unspecified).AddTicks(6255) },
                    { 3, 500m, "Ergonomic Frozen Mouse", new DateTime(2025, 10, 14, 7, 12, 47, 572, DateTimeKind.Unspecified).AddTicks(2310), new DateTime(2026, 4, 14, 7, 12, 47, 572, DateTimeKind.Unspecified).AddTicks(2310) },
                    { 4, 2000m, "Licensed Metal Chair", new DateTime(2023, 9, 10, 10, 43, 2, 195, DateTimeKind.Unspecified).AddTicks(1441), new DateTime(2025, 1, 10, 10, 43, 2, 195, DateTimeKind.Unspecified).AddTicks(1441) },
                    { 5, 2000m, "Intelligent Soft Car", new DateTime(2025, 6, 27, 7, 2, 51, 137, DateTimeKind.Unspecified).AddTicks(9959), new DateTime(2026, 7, 27, 7, 2, 51, 137, DateTimeKind.Unspecified).AddTicks(9959) }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Weissnat - Collins" },
                    { 2, "Gutmann, Ledner and Wisozk" },
                    { 3, "Goyette LLC" },
                    { 4, "Brakus - Lindgren" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
                    { 1, "Jared.Willms32@yahoo.com", false, "Petra8" },
                    { 2, "Columbus62@gmail.com", false, "Eden_Herzog61" },
                    { 3, "Lavon16@hotmail.com", false, "Maci.Roberts73" },
                    { 4, "Jamarcus57@yahoo.com", false, "Jewell68" },
                    { 5, "Marc95@hotmail.com", true, "Karina33" },
                    { 6, "Chase.Wehner@hotmail.com", false, "Bethel.Lind" },
                    { 7, "Jonathan.Hammes@hotmail.com", false, "Jaclyn.Walter" },
                    { 8, "Dallin_Rath9@gmail.com", false, "Cleo69" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CoverImageName", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 3, null, "Maxime qui quia adipisci corporis tempora. Sed sed cupiditate. Necessitatibus quidem et dignissimos unde eius et doloremque aut.", 1, "4559234765293", 5, 16.70m, 3, "Sunt architecto nulla voluptas." },
                    { 2, 5, null, "Sed dignissimos est minima nemo. Corrupti veritatis impedit est qui in soluta facilis qui. Et necessitatibus corrupti dolorem quibusdam officiis quia.", 1, "3877837529434", 2, 13.01m, 2, "Qui asperiores rem dolore ab." },
                    { 3, 3, null, "Magni sit molestias non voluptates voluptatibus. Cum itaque facere. Voluptatem quam mollitia sed dignissimos neque vitae.", 7, "6594889781678", 4, 9.88m, 4, "Et ratione itaque officiis et." },
                    { 4, 3, null, "Ab voluptas facere quas illo ullam. Amet eligendi dolorem est architecto. Molestias autem voluptatem voluptatem odio blanditiis aut numquam laborum. Ratione quidem accusantium aliquam exercitationem animi et rerum. Aut commodi temporibus non explicabo dignissimos. Quas maxime voluptas ex animi odit odio fuga.", 5, "1402338747890", 3, 9.34m, 4, "Quia molestiae quibusdam iure rerum qui." }
                });

            migrationBuilder.InsertData(
                table: "GiftcardCode",
                columns: new[] { "Id", "Code", "GiftcardId", "IsUsed", "OrderId" },
                values: new object[,]
                {
                    { 1, "GC-9692-6060", 1, false, null },
                    { 2, "GC-6327-9370", 1, false, null },
                    { 3, "GC-1356-1691", 1, false, null },
                    { 4, "GC-0966-2349", 1, false, null },
                    { 5, "GC-8546-3358", 1, false, null },
                    { 6, "GC-8712-9502", 1, true, null },
                    { 7, "GC-2795-9212", 1, false, null },
                    { 8, "GC-8445-8702", 1, true, null },
                    { 9, "GC-6320-6406", 1, false, null },
                    { 10, "GC-9707-5660", 1, false, null },
                    { 11, "GC-6320-3560", 2, false, null },
                    { 12, "GC-7262-1589", 2, false, null },
                    { 13, "GC-8727-4271", 2, false, null },
                    { 14, "GC-9373-5913", 2, false, null },
                    { 15, "GC-2707-8952", 2, false, null },
                    { 16, "GC-9177-7772", 2, false, null },
                    { 17, "GC-6720-6532", 2, false, null },
                    { 18, "GC-1620-5488", 2, false, null },
                    { 19, "GC-3582-9488", 2, false, null },
                    { 20, "GC-5339-1487", 2, false, null },
                    { 21, "GC-3634-3208", 3, false, null },
                    { 22, "GC-6138-8675", 3, false, null },
                    { 23, "GC-5130-7042", 3, false, null },
                    { 24, "GC-1448-1712", 3, false, null },
                    { 25, "GC-9532-5346", 3, true, null },
                    { 26, "GC-2256-0519", 3, false, null },
                    { 27, "GC-1784-4760", 3, false, null },
                    { 28, "GC-0785-2909", 3, false, null },
                    { 29, "GC-1637-4489", 3, false, null },
                    { 30, "GC-9466-0349", 3, false, null },
                    { 31, "GC-4199-5594", 4, true, null },
                    { 32, "GC-7719-1007", 4, true, null },
                    { 33, "GC-5838-2375", 4, false, null },
                    { 34, "GC-3162-2360", 4, false, null },
                    { 35, "GC-8221-6733", 4, true, null },
                    { 36, "GC-4717-6531", 4, false, null },
                    { 37, "GC-2818-5115", 4, false, null },
                    { 38, "GC-8187-3818", 4, true, null },
                    { 39, "GC-8602-0708", 4, false, null },
                    { 40, "GC-9375-2852", 4, true, null },
                    { 41, "GC-6186-1646", 5, false, null },
                    { 42, "GC-5502-3201", 5, false, null },
                    { 43, "GC-1899-5090", 5, false, null },
                    { 44, "GC-5292-8829", 5, false, null },
                    { 45, "GC-6494-1419", 5, false, null },
                    { 46, "GC-5780-2027", 5, true, null },
                    { 47, "GC-6982-3132", 5, false, null },
                    { 48, "GC-2375-2018", 5, false, null },
                    { 49, "GC-7997-6030", 5, false, null },
                    { 50, "GC-0847-8855", 5, false, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "GiftcardCodeId", "PaymentStatus", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 14, 23, 30, 49, 410, DateTimeKind.Unspecified).AddTicks(2803), null, 0, 2 },
                    { 2, new DateTime(2015, 6, 14, 5, 32, 59, 785, DateTimeKind.Unspecified).AddTicks(2081), null, 0, 3 },
                    { 3, new DateTime(2019, 2, 24, 6, 24, 47, 77, DateTimeKind.Unspecified).AddTicks(2588), null, 0, 8 },
                    { 4, new DateTime(2022, 2, 2, 17, 9, 56, 626, DateTimeKind.Unspecified).AddTicks(5838), null, 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Provident libero dolor sunt sed error aut voluptatem accusantium.", 3, 4, 2 },
                    { 2, "Ex laborum sapiente et dolorem doloribus ut sed commodi.", 4, 3, 4 },
                    { 3, "Pariatur ad temporibus eos eveniet vel culpa nisi.", 2, 1, 5 },
                    { 4, "Architecto id qui eius velit ut ea expedita voluptatem corrupti.", 3, 4, 7 },
                    { 5, "Ea facilis nam alias ut corrupti maxime cupiditate perferendis.", 1, 1, 2 },
                    { 6, "Dolor quis ducimus eveniet enim quae accusamus ut libero.", 1, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 3, 4, 2 },
                    { 2, 4, 5, 7 },
                    { 3, 4, 3, 2 },
                    { 4, 1, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "GenreBooks",
                columns: new[] { "Id", "BookId", "GenreId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 1, 5, false },
                    { 2, 1, 7, true },
                    { 3, 1, 3, false },
                    { 4, 2, 7, false },
                    { 5, 2, 5, true },
                    { 6, 3, 6, true },
                    { 7, 3, 3, false },
                    { 8, 4, 3, false },
                    { 9, 4, 1, true }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookAuthor", "BookISBN", "BookPrice", "BookPublisher", "BookTitle", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, "BrycenDenesik", "4559234765293", 16.70m, "Hahn and Sons", "Sunt architecto nulla voluptas.", 1, 2 },
                    { 2, "RachelRobel", "4559234765293", 16.70m, "Sporer, Walter and Anderson", "Sunt architecto nulla voluptas.", 2, 2 },
                    { 3, "KeithRoob", "1402338747890", 9.34m, "Bergstrom - Moore", "Quia molestiae quibusdam iure rerum qui.", 3, 1 },
                    { 4, "MartyCrooks", "1402338747890", 9.34m, "Donnelly - Moore", "Quia molestiae quibusdam iure rerum qui.", 3, 3 },
                    { 5, "IsmaelCorkery", "4559234765293", 16.70m, "Jakubowski Group", "Sunt architecto nulla voluptas.", 3, 5 },
                    { 6, "TerrellBarton", "3877837529434", 13.01m, "Price LLC", "Qui asperiores rem dolore ab.", 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LastEditedById",
                table: "Book",
                column: "LastEditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_BookId",
                table: "BookReview",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_UserId",
                table: "BookReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BookId",
                table: "CartItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_UserId",
                table: "CartItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_BookId_IsPrimary",
                table: "GenreBooks",
                columns: new[] { "BookId", "IsPrimary" },
                unique: true,
                filter: "[IsPrimary] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_GenreId",
                table: "GenreBooks",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftcardCode_GiftcardId",
                table: "GiftcardCode",
                column: "GiftcardId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftcardCode_OrderId",
                table: "GiftcardCode",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_GiftcardCodeId",
                table: "Order",
                column: "GiftcardCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_BookId",
                table: "WishlistItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_UserId",
                table: "WishlistItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftcardCode_Order_OrderId",
                table: "GiftcardCode",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftcardCode_Giftcard_GiftcardId",
                table: "GiftcardCode");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftcardCode_Order_OrderId",
                table: "GiftcardCode");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookReview");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "GenreBooks");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "WishlistItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Giftcard");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "GiftcardCode");
        }
    }
}
