using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "Emerald", "Senger" },
                    { 2, "Robbie", "Wilderman" },
                    { 3, "Dax", "MacGyver" },
                    { 4, "Hortense", "Romaguera" },
                    { 5, "Gudrun", "Mann" }
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
                    { 1, 250m, "Gorgeous Steel Keyboard", new DateTime(2023, 6, 18, 19, 1, 12, 14, DateTimeKind.Unspecified).AddTicks(4114), new DateTime(2024, 10, 18, 19, 1, 12, 14, DateTimeKind.Unspecified).AddTicks(4114) },
                    { 2, 2000m, "Tasty Soft Keyboard", new DateTime(2023, 11, 24, 23, 38, 44, 729, DateTimeKind.Unspecified).AddTicks(9821), new DateTime(2025, 5, 24, 23, 38, 44, 729, DateTimeKind.Unspecified).AddTicks(9821) },
                    { 3, 500m, "Fantastic Granite Pants", new DateTime(2023, 6, 23, 6, 31, 49, 17, DateTimeKind.Unspecified).AddTicks(5070), new DateTime(2024, 11, 23, 6, 31, 49, 17, DateTimeKind.Unspecified).AddTicks(5070) },
                    { 4, 500m, "Small Frozen Keyboard", new DateTime(2024, 4, 3, 15, 8, 13, 910, DateTimeKind.Unspecified).AddTicks(6024), new DateTime(2025, 2, 3, 15, 8, 13, 910, DateTimeKind.Unspecified).AddTicks(6024) },
                    { 5, 2000m, "Awesome Plastic Fish", new DateTime(2024, 2, 19, 12, 42, 4, 797, DateTimeKind.Unspecified).AddTicks(105), new DateTime(2024, 8, 19, 12, 42, 4, 797, DateTimeKind.Unspecified).AddTicks(105) }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grady - Reilly" },
                    { 2, "Auer, Wilderman and Cormier" },
                    { 3, "Howe Group" },
                    { 4, "Shields LLC" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
                    { 1, "Halle_Lehner63@hotmail.com", false, "Gage.VonRueden96" },
                    { 2, "Paul_Gorczany@hotmail.com", false, "Guadalupe31" },
                    { 3, "Icie_Rutherford43@hotmail.com", false, "Deion.Bashirian" },
                    { 4, "Marlon68@yahoo.com", false, "Natasha77" },
                    { 5, "Leonardo65@yahoo.com", false, "Gretchen_Dare" },
                    { 6, "Fannie.Lakin9@hotmail.com", false, "Eulah47" },
                    { 7, "Mohammed.Gerhold99@yahoo.com", false, "Destini.Pfannerstill" },
                    { 8, "Erik.Bailey@hotmail.com", false, "Trenton.Schaefer51" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CoverImageName", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 3, null, "Porro enim suscipit sed. Soluta maxime et quo tempora. Ipsum corrupti et ad qui deserunt in et praesentium ut. Ipsa doloremque voluptatem libero hic doloribus rerum iste atque. Et omnis delectus.", 1, "0911314746372", 3, 19.15m, 1, "Corporis iure voluptatem eum sed veniam." },
                    { 2, 2, null, "Labore et voluptatum itaque libero alias qui ullam eveniet. Laudantium voluptatem et et sed. Autem dolor repellendus rerum non distinctio voluptatem est cum adipisci.", 0, "7433615861507", 2, 18.49m, 3, "Quas veniam aspernatur ut." },
                    { 3, 1, null, "Rem saepe iure adipisci eligendi error. Ut quo repellendus voluptas necessitatibus et ut sapiente. Ut ea consequatur.", 1, "4789258920051", 1, 9.92m, 4, "Eos architecto id iste maiores error." },
                    { 4, 3, null, "Dolorem dolore architecto magni quibusdam temporibus. Quod laboriosam excepturi. Enim et corrupti accusamus maiores velit et. Voluptatum saepe quod minus repellendus placeat quia id eveniet velit. Fugit optio provident. Ipsam fugit et repudiandae natus quos accusantium ducimus.", 5, "5652596082882", 1, 16.14m, 4, "Sint iusto dolorem architecto dolorem placeat." }
                });

            migrationBuilder.InsertData(
                table: "GiftcardCode",
                columns: new[] { "Id", "Code", "GiftcardId", "IsUsed", "OrderId" },
                values: new object[,]
                {
                    { 1, "GC-2067-0459", 1, false, null },
                    { 2, "GC-9162-0020", 1, false, null },
                    { 3, "GC-2242-2861", 1, true, null },
                    { 4, "GC-0963-1222", 1, false, null },
                    { 5, "GC-1303-4709", 1, false, null },
                    { 6, "GC-9585-6193", 1, false, null },
                    { 7, "GC-1645-7220", 1, false, null },
                    { 8, "GC-7982-8168", 1, false, null },
                    { 9, "GC-5950-4042", 1, false, null },
                    { 10, "GC-0063-4668", 1, false, null },
                    { 11, "GC-9356-3928", 2, false, null },
                    { 12, "GC-2280-5483", 2, false, null },
                    { 13, "GC-3324-7884", 2, false, null },
                    { 14, "GC-4188-7925", 2, false, null },
                    { 15, "GC-1714-6469", 2, false, null },
                    { 16, "GC-1181-8289", 2, false, null },
                    { 17, "GC-5545-6429", 2, true, null },
                    { 18, "GC-6972-5613", 2, false, null },
                    { 19, "GC-4412-4721", 2, false, null },
                    { 20, "GC-2351-2467", 2, false, null },
                    { 21, "GC-4752-0825", 3, false, null },
                    { 22, "GC-6707-3359", 3, false, null },
                    { 23, "GC-8384-2395", 3, false, null },
                    { 24, "GC-2903-0306", 3, false, null },
                    { 25, "GC-6055-3573", 3, true, null },
                    { 26, "GC-8162-4513", 3, false, null },
                    { 27, "GC-7595-4089", 3, false, null },
                    { 28, "GC-0114-7627", 3, true, null },
                    { 29, "GC-4438-7079", 3, false, null },
                    { 30, "GC-0044-5440", 3, false, null },
                    { 31, "GC-0596-2995", 4, true, null },
                    { 32, "GC-7734-5939", 4, true, null },
                    { 33, "GC-1025-8845", 4, true, null },
                    { 34, "GC-5326-1317", 4, false, null },
                    { 35, "GC-7444-9232", 4, false, null },
                    { 36, "GC-0959-9803", 4, true, null },
                    { 37, "GC-0986-5730", 4, true, null },
                    { 38, "GC-7604-0899", 4, false, null },
                    { 39, "GC-7143-9475", 4, false, null },
                    { 40, "GC-4506-8477", 4, true, null },
                    { 41, "GC-7500-8996", 5, false, null },
                    { 42, "GC-6251-9180", 5, true, null },
                    { 43, "GC-0490-3319", 5, false, null },
                    { 44, "GC-8727-2649", 5, false, null },
                    { 45, "GC-4655-6927", 5, false, null },
                    { 46, "GC-8245-5832", 5, false, null },
                    { 47, "GC-1040-8942", 5, false, null },
                    { 48, "GC-6635-3263", 5, false, null },
                    { 49, "GC-4682-5804", 5, false, null },
                    { 50, "GC-6301-7067", 5, false, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "GiftcardCodeId", "PaymentStatus", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 5, 5, 23, 25, 15, 929, DateTimeKind.Unspecified).AddTicks(1720), null, 0, 5 },
                    { 2, new DateTime(2020, 5, 5, 0, 59, 57, 630, DateTimeKind.Unspecified).AddTicks(9772), null, 0, 3 },
                    { 3, new DateTime(2021, 10, 7, 14, 33, 12, 198, DateTimeKind.Unspecified).AddTicks(2334), null, 0, 3 },
                    { 4, new DateTime(2024, 10, 30, 18, 29, 8, 107, DateTimeKind.Unspecified).AddTicks(8890), null, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Cupiditate rem quas minima ipsa impedit quia voluptas quos nam.", 3, 2, 4 },
                    { 2, "Et neque omnis eveniet error enim inventore et veniam.", 2, 3, 1 },
                    { 3, "Qui facere optio ullam qui alias doloremque quos facilis officia.", 1, 2, 2 },
                    { 4, "Tempora ut architecto id fugiat qui et deserunt ut.", 1, 3, 4 },
                    { 5, "Maiores deleniti consequatur in soluta debitis cumque voluptatem.", 4, 5, 6 },
                    { 6, "Autem ea excepturi ipsum ducimus perspiciatis est autem.", 4, 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 4, 3, 1 },
                    { 2, 3, 1, 3 },
                    { 3, 1, 5, 3 },
                    { 4, 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "GenreBooks",
                columns: new[] { "Id", "BookId", "GenreId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 1, 2, true },
                    { 2, 1, 5, false },
                    { 3, 1, 4, false },
                    { 4, 2, 6, false },
                    { 5, 2, 5, true },
                    { 6, 3, 1, false },
                    { 7, 3, 4, true },
                    { 8, 3, 5, false },
                    { 9, 4, 8, false },
                    { 10, 4, 1, true }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, 1, 3 },
                    { 2, 3, 1, 1 },
                    { 3, 2, 1, 2 },
                    { 4, 1, 2, 5 },
                    { 5, 3, 2, 5 },
                    { 6, 4, 2, 3 },
                    { 7, 1, 3, 5 },
                    { 8, 2, 3, 5 },
                    { 9, 1, 3, 2 },
                    { 10, 2, 4, 2 },
                    { 11, 1, 4, 4 },
                    { 12, 3, 4, 1 }
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
                name: "IX_OrderItem_BookId",
                table: "OrderItem",
                column: "BookId");

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
