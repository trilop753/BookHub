using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
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
                    { 1, "Jovan", "Leuschke" },
                    { 2, "Trudie", "Johnson" },
                    { 3, "Charity", "Rutherford" },
                    { 4, "Neoma", "Hammes" },
                    { 5, "Eddie", "O'Kon" }
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
                    { 1, 250m, "Sleek Fresh Shirt", new DateTime(2023, 5, 27, 12, 14, 39, 781, DateTimeKind.Unspecified).AddTicks(7476), new DateTime(2024, 3, 27, 12, 14, 39, 781, DateTimeKind.Unspecified).AddTicks(7476) },
                    { 2, 250m, "Tasty Cotton Towels", new DateTime(2025, 7, 25, 18, 42, 43, 291, DateTimeKind.Unspecified).AddTicks(643), new DateTime(2027, 1, 25, 18, 42, 43, 291, DateTimeKind.Unspecified).AddTicks(643) },
                    { 3, 500m, "Rustic Frozen Hat", new DateTime(2025, 4, 11, 5, 2, 11, 709, DateTimeKind.Unspecified).AddTicks(5554), new DateTime(2026, 5, 11, 5, 2, 11, 709, DateTimeKind.Unspecified).AddTicks(5554) },
                    { 4, 1000m, "Refined Wooden Pants", new DateTime(2024, 2, 28, 8, 21, 14, 309, DateTimeKind.Unspecified).AddTicks(6378), new DateTime(2025, 2, 28, 8, 21, 14, 309, DateTimeKind.Unspecified).AddTicks(6378) },
                    { 5, 500m, "Awesome Granite Chicken", new DateTime(2023, 7, 14, 7, 45, 2, 497, DateTimeKind.Unspecified).AddTicks(4361), new DateTime(2024, 10, 14, 7, 45, 2, 497, DateTimeKind.Unspecified).AddTicks(4361) }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Christiansen Group" },
                    { 2, "Gulgowski, Keeling and Parisian" },
                    { 3, "Funk - Johns" },
                    { 4, "Grady and Sons" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
                    { 1, "Clifford_Thiel18@hotmail.com", false, "Bailey.Ritchie" },
                    { 2, "Brenda.Dickens@hotmail.com", false, "Asa83" },
                    { 3, "Vaughn9@hotmail.com", false, "Elmira.Johnston76" },
                    { 4, "Ebba.Gislason@gmail.com", true, "Jamie.Aufderhar" },
                    { 5, "Tressa.Will@hotmail.com", false, "Angelica45" },
                    { 6, "Daisy_Huels2@yahoo.com", false, "Zackery_Abbott30" },
                    { 7, "Clemens.Marquardt@hotmail.com", false, "Adaline.Fritsch98" },
                    { 8, "Alana_Kohler5@yahoo.com", false, "Carroll_Pfeffer" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CoverImageName", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "Corporis possimus dolore. Beatae suscipit exercitationem quo asperiores in et rerum illo. Itaque aut omnis minus autem commodi quae iusto. Sed omnis saepe illum quisquam et commodi.", 4, "7848910114492", 5, 17.55m, 1, "Culpa totam fugiat dolores nisi." },
                    { 2, 1, null, "Qui quibusdam reiciendis debitis. Odio labore et in culpa illo nihil iure consequatur est. Placeat veniam culpa. Sed sed harum ex. Numquam sed perspiciatis sint totam tempora quis.", 7, "5762633662677", 1, 13.08m, 2, "Qui aspernatur et quia autem." },
                    { 3, 5, null, "Velit incidunt blanditiis qui tempora perferendis placeat officiis iusto. Perferendis recusandae a nemo praesentium quo mollitia. Sed quasi veritatis. Dolores impedit aut.", 7, "3349167135178", 4, 15.07m, 3, "Ut est nam placeat." },
                    { 4, 1, null, "Tenetur et nobis delectus. Est sed laborum quis blanditiis sit atque eos. Dolorum ipsa et libero quae dolorem sit. Nihil ipsam ex quos maxime omnis quam molestiae repellendus.", 9, "5018325791904", 4, 9.45m, 3, "Ab laborum quam illo aperiam et." }
                });

            migrationBuilder.InsertData(
                table: "GiftcardCode",
                columns: new[] { "Id", "Code", "GiftcardId", "IsUsed", "OrderId" },
                values: new object[,]
                {
                    { 1, "GC-7744-1344", 1, false, null },
                    { 2, "GC-2531-3864", 1, false, null },
                    { 3, "GC-9400-6910", 1, false, null },
                    { 4, "GC-1879-3962", 1, false, null },
                    { 5, "GC-6652-6248", 1, false, null },
                    { 6, "GC-8052-5006", 1, false, null },
                    { 7, "GC-5614-5024", 1, false, null },
                    { 8, "GC-7717-9405", 1, true, null },
                    { 9, "GC-9444-0029", 1, true, null },
                    { 10, "GC-9754-6282", 1, false, null },
                    { 11, "GC-5894-2306", 2, false, null },
                    { 12, "GC-2615-1727", 2, false, null },
                    { 13, "GC-5475-5262", 2, false, null },
                    { 14, "GC-8916-0466", 2, false, null },
                    { 15, "GC-3288-6161", 2, false, null },
                    { 16, "GC-2878-4159", 2, false, null },
                    { 17, "GC-4450-8065", 2, false, null },
                    { 18, "GC-5125-6939", 2, false, null },
                    { 19, "GC-6797-5214", 2, false, null },
                    { 20, "GC-4575-5874", 2, false, null },
                    { 21, "GC-9681-2410", 3, false, null },
                    { 22, "GC-0156-9006", 3, false, null },
                    { 23, "GC-3155-3208", 3, false, null },
                    { 24, "GC-8307-1627", 3, false, null },
                    { 25, "GC-3814-5894", 3, false, null },
                    { 26, "GC-6221-4634", 3, true, null },
                    { 27, "GC-4294-3052", 3, false, null },
                    { 28, "GC-0954-6183", 3, false, null },
                    { 29, "GC-5163-4935", 3, false, null },
                    { 30, "GC-3226-6911", 3, false, null },
                    { 31, "GC-8743-1700", 4, false, null },
                    { 32, "GC-4297-7174", 4, false, null },
                    { 33, "GC-1710-0224", 4, false, null },
                    { 34, "GC-0353-3907", 4, false, null },
                    { 35, "GC-5422-1771", 4, false, null },
                    { 36, "GC-8578-6448", 4, false, null },
                    { 37, "GC-7673-1759", 4, false, null },
                    { 38, "GC-3010-7161", 4, false, null },
                    { 39, "GC-2761-4547", 4, false, null },
                    { 40, "GC-5929-2007", 4, false, null },
                    { 41, "GC-1341-0336", 5, false, null },
                    { 42, "GC-1525-7423", 5, false, null },
                    { 43, "GC-4722-3100", 5, false, null },
                    { 44, "GC-4756-0443", 5, false, null },
                    { 45, "GC-0226-5718", 5, true, null },
                    { 46, "GC-4946-6255", 5, true, null },
                    { 47, "GC-6233-2312", 5, false, null },
                    { 48, "GC-3752-5434", 5, false, null },
                    { 49, "GC-4338-6668", 5, false, null },
                    { 50, "GC-0930-5388", 5, false, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "GiftcardCodeId", "PaymentStatus", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 18, 1, 32, 32, 547, DateTimeKind.Unspecified).AddTicks(304), null, 0, 3 },
                    { 2, new DateTime(2020, 7, 17, 21, 0, 9, 245, DateTimeKind.Unspecified).AddTicks(4721), null, 0, 6 },
                    { 3, new DateTime(2025, 5, 12, 14, 13, 33, 217, DateTimeKind.Unspecified).AddTicks(4704), null, 0, 7 },
                    { 4, new DateTime(2015, 10, 2, 5, 39, 5, 219, DateTimeKind.Unspecified).AddTicks(5823), null, 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Quis illo dolorum suscipit sit inventore sunt iure veniam.", 4, 2, 4 },
                    { 2, "Autem ab et tempore voluptatem porro impedit eius.", 4, 3, 2 },
                    { 3, "Libero distinctio magni incidunt dolor sed sit ut.", 4, 4, 8 },
                    { 4, "Dolores dolorum harum nihil voluptates molestiae consequuntur dolor illo ratione.", 4, 3, 8 },
                    { 5, "Tempore optio hic aliquam blanditiis vero illum vel corrupti.", 2, 4, 8 },
                    { 6, "Aliquam sint ut ut qui sed nisi repellat blanditiis.", 4, 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 4, 3 },
                    { 2, 1, 4, 7 },
                    { 3, 3, 5, 6 },
                    { 4, 3, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "GenreBooks",
                columns: new[] { "Id", "BookId", "GenreId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 1, 2, false },
                    { 2, 1, 6, true },
                    { 3, 2, 2, true },
                    { 4, 2, 8, false },
                    { 5, 3, 8, true },
                    { 6, 3, 7, false },
                    { 7, 4, 1, false },
                    { 8, 4, 6, false },
                    { 9, 4, 4, true }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookAuthor", "BookISBN", "BookPrice", "BookPublisher", "BookTitle", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, "StephonHills", "3349167135178", 15.07m, "Denesik Group", "Ut est nam placeat.", 1, 3 },
                    { 2, "ShaunGislason", "5762633662677", 13.08m, "Willms, Wisoky and Feil", "Qui aspernatur et quia autem.", 1, 1 },
                    { 3, "MicahBradtke", "3349167135178", 15.07m, "Raynor - Marks", "Ut est nam placeat.", 2, 1 },
                    { 4, "ChristopheHoppe", "3349167135178", 15.07m, "Shanahan LLC", "Ut est nam placeat.", 2, 1 },
                    { 5, "AltheaHackett", "5762633662677", 13.08m, "Waters, Mayer and Stroman", "Qui aspernatur et quia autem.", 3, 1 },
                    { 6, "LennaSchuster", "7848910114492", 17.55m, "Yost - VonRueden", "Culpa totam fugiat dolores nisi.", 3, 1 },
                    { 7, "TitoBartoletti", "5762633662677", 13.08m, "VonRueden - Torp", "Qui aspernatur et quia autem.", 3, 4 },
                    { 8, "AdelbertBlick", "5762633662677", 13.08m, "Goodwin LLC", "Qui aspernatur et quia autem.", 4, 5 }
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
