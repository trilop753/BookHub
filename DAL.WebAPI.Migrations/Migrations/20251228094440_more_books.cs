using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebAPI.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class more_books : Migration
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
                    { 1, "August", "McDermott" },
                    { 2, "Taryn", "Deckow" },
                    { 3, "Noelia", "Schultz" },
                    { 4, "Ezequiel", "Weimann" },
                    { 5, "Kasandra", "Keebler" }
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
                    { 1, 1000m, "Licensed Metal Bacon", new DateTime(2023, 3, 29, 12, 44, 22, 689, DateTimeKind.Unspecified).AddTicks(1154), new DateTime(2024, 1, 29, 12, 44, 22, 689, DateTimeKind.Unspecified).AddTicks(1154) },
                    { 2, 2000m, "Handcrafted Plastic Table", new DateTime(2024, 5, 20, 2, 22, 50, 783, DateTimeKind.Unspecified).AddTicks(7165), new DateTime(2025, 8, 20, 2, 22, 50, 783, DateTimeKind.Unspecified).AddTicks(7165) },
                    { 3, 250m, "Tasty Concrete Chips", new DateTime(2024, 8, 27, 22, 46, 0, 830, DateTimeKind.Unspecified).AddTicks(3217), new DateTime(2025, 7, 27, 22, 46, 0, 830, DateTimeKind.Unspecified).AddTicks(3217) },
                    { 4, 500m, "Rustic Frozen Car", new DateTime(2023, 8, 28, 9, 44, 55, 16, DateTimeKind.Unspecified).AddTicks(6819), new DateTime(2024, 9, 28, 9, 44, 55, 16, DateTimeKind.Unspecified).AddTicks(6819) },
                    { 5, 2000m, "Awesome Metal Tuna", new DateTime(2023, 8, 4, 21, 26, 6, 866, DateTimeKind.Unspecified).AddTicks(4950), new DateTime(2024, 8, 4, 21, 26, 6, 866, DateTimeKind.Unspecified).AddTicks(4950) }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pollich, Littel and Wunsch" },
                    { 2, "Marquardt and Sons" },
                    { 3, "Halvorson, Goldner and Auer" },
                    { 4, "Jacobs - Roberts" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
                    { 1, "Brice_Cremin25@yahoo.com", false, "Reyna91" },
                    { 2, "Aliya.Osinski@yahoo.com", false, "Vida76" },
                    { 3, "Don.Brown@yahoo.com", false, "Gilda.Von" },
                    { 4, "Rosie_Fisher80@gmail.com", false, "Theresia_Goyette40" },
                    { 5, "Eliseo82@gmail.com", false, "Monique_Waelchi70" },
                    { 6, "Modesto.Graham65@yahoo.com", false, "Wendell58" },
                    { 7, "Joy_Welch38@hotmail.com", false, "Gunner.Reynolds34" },
                    { 8, "Jerry.Reilly90@hotmail.com", false, "Aron_Balistreri9" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CoverImageName", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 2, null, "Animi qui nesciunt sit velit. Ut quia iure quam est ea. Quasi debitis laudantium maiores iusto deleniti non accusantium est. Sequi quae distinctio exercitationem doloribus quibusdam. Ipsam earum esse fugiat.", 10, "0420919923724", 2, 11.92m, 4, "Optio voluptates expedita qui aut reiciendis." },
                    { 2, 2, null, "Dolorum et et officiis exercitationem. Eius quo debitis nostrum et. Rerum qui est corrupti aut ullam dicta eius vel et. Alias aliquam modi modi ex suscipit quia quia.", 10, "1330847226899", 4, 19.77m, 4, "Et id quaerat praesentium architecto." },
                    { 3, 2, null, "Cumque odit quasi omnis. Consequatur incidunt et sed veniam officia. Blanditiis dicta laudantium aperiam quia repellendus harum.", 9, "1937011740597", 5, 17.42m, 3, "Aut praesentium exercitationem sed." },
                    { 4, 3, null, "Sequi nemo minima. Laborum iusto sint ut impedit sunt quaerat voluptate ducimus cupiditate. Quo facere et voluptates facilis sequi.", 6, "2889179440347", 1, 7.57m, 4, "Aliquam omnis quidem modi exercitationem." },
                    { 5, 3, null, "Aperiam dignissimos nisi incidunt qui qui fuga expedita voluptatem. Ut laboriosam reprehenderit explicabo ipsum. Quo sunt ab. Et magni voluptatem autem alias dolores ex aut eveniet consequatur. Quae et reprehenderit fuga eaque. Autem qui reprehenderit molestias.", 3, "3738915729835", 2, 9.67m, 4, "Eius eum veritatis quaerat." },
                    { 6, 5, null, "Dicta aspernatur et. Nobis possimus ut facere eaque. Accusamus est facere natus dolorem harum qui cupiditate. Blanditiis aliquam voluptas esse cum inventore ut vero omnis ad. Qui cum aperiam esse qui aut ut delectus. Ut ut facilis beatae aut doloribus illo et numquam.", 3, "3437298580377", 2, 16.02m, 2, "In sed consectetur reprehenderit sequi quos." },
                    { 7, 5, null, "Id sequi vero ut molestiae iste. Accusantium dolore quibusdam nihil et aut voluptatibus enim porro at. Nemo occaecati maiores nemo asperiores qui porro et. Quia sed velit.", 8, "6909234594382", 3, 17.62m, 3, "Dolores dolorum modi corrupti." },
                    { 8, 3, null, "Ipsam consequatur aperiam. Necessitatibus ea voluptatem delectus expedita repudiandae qui assumenda. Et suscipit nihil esse est.", 1, "2897586835489", 2, 15.89m, 1, "Possimus dolor atque repellat." },
                    { 9, 1, null, "Velit facere consequuntur voluptatum ducimus veniam assumenda veritatis eveniet. Perferendis molestias aut enim id aut molestiae quaerat doloremque. Voluptatem blanditiis molestias quia assumenda sapiente officiis qui consequatur ea. Aut aperiam eum natus officiis sit minima voluptate. Impedit hic facilis qui. Harum et accusamus.", 8, "0506092630717", 4, 8.34m, 3, "Et reiciendis praesentium exercitationem accusantium accusantium." },
                    { 10, 2, null, "Sed et culpa error. Ipsum cupiditate eos consequatur sapiente. Cum ducimus corrupti eaque eligendi recusandae libero. Omnis repellendus dignissimos recusandae eos dolor voluptas modi. Reprehenderit maxime rerum nihil beatae minima.", 6, "0542480480496", 5, 14.05m, 1, "Cumque cumque tempora aut beatae blanditiis." },
                    { 11, 1, null, "Quisquam et eos. Voluptatem officia quam totam quo asperiores id enim reiciendis blanditiis. Quae eaque sint cumque.", 7, "7053354176948", 3, 14.61m, 4, "Dolores et qui fugiat harum." },
                    { 12, 2, null, "Adipisci neque tenetur quis repellendus aut. Sit qui fugit quisquam provident dignissimos quaerat aut magni fuga. Unde odio temporibus aut et exercitationem nesciunt autem recusandae distinctio. Inventore non ducimus eligendi odio provident amet quae accusantium. Ut pariatur hic nesciunt ducimus autem iusto et quo possimus. Quis reiciendis et quod qui qui nihil itaque fuga aperiam.", 10, "7821457113258", 5, 19.34m, 3, "Ipsa voluptas beatae voluptate laboriosam." },
                    { 13, 5, null, "Qui debitis culpa et. Quisquam molestiae sed necessitatibus voluptatem. Eius ut sit sunt vel eos est animi.", 0, "8699907341044", 1, 18.68m, 2, "Aperiam similique consequuntur et voluptate saepe." },
                    { 14, 1, null, "Animi consequatur voluptatem ad quam recusandae sit. In vero sunt optio nesciunt. Omnis impedit maxime incidunt enim saepe suscipit. Repellat qui qui vel dolorem eveniet perspiciatis rerum distinctio amet. Magni dolorem nemo unde sit iste nemo et.", 4, "5784656646946", 2, 18.01m, 1, "Deleniti qui dolores facilis non." },
                    { 15, 5, null, "Laboriosam eum ex minus est asperiores deserunt dolor excepturi. Ut dolores molestiae sunt voluptatem neque rerum. Magnam enim velit omnis quos sint. Quia optio debitis velit est sed ut commodi. Omnis perspiciatis quia placeat minus. At culpa optio consequuntur ratione accusantium.", 5, "9440463495028", 5, 14.81m, 3, "Dolor quidem illum saepe unde eum." },
                    { 16, 3, null, "Possimus nemo omnis porro. Placeat alias necessitatibus qui possimus in voluptates quo quo occaecati. Dolor reiciendis voluptatum labore neque natus. Saepe incidunt incidunt accusamus fugiat est repellendus quis.", 4, "2224692758539", 5, 10.47m, 4, "Quidem ratione unde aut maxime." },
                    { 17, 5, null, "Dolorem consequatur earum praesentium sint magni dignissimos molestiae. Modi illo sit dignissimos tempore minima. Vitae eos voluptate exercitationem ut sit velit odit. Id dolorum sed id ea nihil iure. Ad voluptatum illo consequuntur.", 7, "2373241979748", 1, 11.46m, 2, "Libero qui velit placeat provident." },
                    { 18, 5, null, "Dolorum dolorem dolorem saepe qui. Eius provident quam. Ab beatae corrupti vel molestiae neque eos sit est animi. Minima at enim suscipit et vitae id. Dicta doloremque fugiat sed sapiente velit dignissimos.", 3, "8116540593765", 1, 15.57m, 4, "Est molestiae qui ut suscipit." },
                    { 19, 2, null, "Natus a nostrum quas reiciendis ad voluptas autem. Expedita ut quis fuga voluptatibus consequatur qui saepe omnis quaerat. Nihil dolor cupiditate autem iste impedit voluptatem consequuntur. Modi ex non. Distinctio aut ut est dignissimos consectetur rerum occaecati. Inventore quis et.", 9, "9247679208790", 2, 18.43m, 4, "Quis et quasi eum incidunt." },
                    { 20, 2, null, "Est molestiae officia dolores. Est voluptatem in ipsum quod odit dolor quis. Voluptatem sint sequi necessitatibus itaque commodi autem ab est. Architecto perspiciatis ducimus.", 1, "8067177119142", 5, 7.19m, 3, "Tenetur esse non quia." },
                    { 21, 2, null, "Minima atque nihil sed tempore. Odit odio ducimus id. Unde harum eum. Et et doloribus sit ut quo pariatur explicabo. Voluptatibus hic ea consequatur. Magnam quasi omnis pariatur.", 5, "6326396621761", 4, 19.54m, 2, "Ipsam reiciendis natus dignissimos." },
                    { 22, 1, null, "Quisquam rerum et ut nostrum dolorum et libero molestiae. Accusantium et rem sint reprehenderit rerum molestiae. Sunt earum deserunt et officia possimus enim. In voluptatibus quod et culpa voluptas molestias voluptatem sed.", 3, "5236199347243", 1, 10.55m, 2, "Tempora mollitia aut nulla eaque." },
                    { 23, 5, null, "Quibusdam recusandae quae facere. Odio cupiditate autem dolorem nesciunt et impedit voluptas dolorum illo. Earum optio ullam corrupti id.", 9, "9156708455008", 5, 10.32m, 3, "Delectus maiores quas molestiae." },
                    { 24, 1, null, "Quo eos qui voluptatem molestiae iste. Quisquam ipsam distinctio quae sit sed quam. Quis et esse ipsam sed quo deleniti. Natus deleniti omnis doloribus commodi beatae tempore assumenda. Ratione qui officiis quis. Vel nulla nam corrupti pariatur aut enim repellendus.", 4, "4174860070995", 5, 19.80m, 1, "Possimus beatae minus rem dolorum." },
                    { 25, 5, null, "Aspernatur sint qui ut vitae ab modi incidunt aut sit. Optio totam qui veritatis consectetur quis dolorem aspernatur. Ut tenetur quis qui et voluptas.", 0, "9674587729237", 3, 10.69m, 3, "Ducimus non accusantium exercitationem recusandae." },
                    { 26, 4, null, "Facilis laudantium ea commodi est. Exercitationem et voluptatem est maxime nihil est occaecati qui neque. Labore facere vel consequuntur.", 6, "6240942677043", 5, 9.29m, 2, "Dolorem architecto deserunt aspernatur." },
                    { 27, 5, null, "Eos qui rerum deleniti. Ex autem accusantium hic consequatur sunt adipisci cumque. Similique quis accusamus alias.", 0, "4625010183091", 5, 10.70m, 2, "Autem qui nesciunt occaecati quae." },
                    { 28, 2, null, "Sed laborum fugit rerum delectus. Minus numquam laboriosam esse. Explicabo voluptatibus nihil odio in aperiam non iure illum. Explicabo quaerat dolores ipsum cupiditate est. Nihil aliquam ad.", 3, "5540797888412", 5, 14.88m, 1, "Quibusdam harum vitae saepe eveniet quo." },
                    { 29, 3, null, "Provident voluptas totam est aliquid. Atque voluptatem suscipit non id nihil sunt aspernatur. Asperiores voluptatem dignissimos neque tenetur quia incidunt. Quasi non eaque odio minima est at.", 6, "0705687012581", 3, 15.72m, 1, "Voluptas aut corporis dolor." },
                    { 30, 2, null, "Accusamus sint quia dolorum voluptate. Officia at sed maiores iusto officiis dolorum perspiciatis porro. Dolore vero distinctio necessitatibus. Maiores laborum sint.", 1, "3873425008305", 1, 8.30m, 1, "Omnis et nobis sunt." },
                    { 31, 3, null, "Et atque sit. Deserunt et est. Eos magni tempora commodi. Et id consequatur est ut provident amet. Quis autem vel. Rerum illo doloremque sunt nihil iste.", 2, "7558108623988", 2, 10.63m, 1, "Magnam nobis similique aperiam doloremque." },
                    { 32, 5, null, "Consequatur veritatis et ratione natus eaque debitis quia eaque dolorum. Corrupti ad iusto voluptas molestiae vel at quibusdam nulla vel. Harum non omnis aut pariatur deserunt fugit quo neque. Expedita provident labore nemo ea ut provident quis nam omnis. Accusamus eligendi dolorem deleniti est. Et illo recusandae et id.", 2, "6331972108819", 5, 7.79m, 1, "Doloremque mollitia consequatur unde." }
                });

            migrationBuilder.InsertData(
                table: "GiftcardCode",
                columns: new[] { "Id", "Code", "GiftcardId", "IsUsed", "OrderId" },
                values: new object[,]
                {
                    { 1, "GC-0148-3968", 1, false, null },
                    { 2, "GC-9355-0558", 1, false, null },
                    { 3, "GC-0189-2299", 1, true, null },
                    { 4, "GC-3304-6205", 1, true, null },
                    { 5, "GC-7969-0083", 1, true, null },
                    { 6, "GC-4157-3024", 1, true, null },
                    { 7, "GC-3762-6333", 1, false, null },
                    { 8, "GC-4188-1008", 1, false, null },
                    { 9, "GC-7511-6529", 1, true, null },
                    { 10, "GC-6802-9868", 1, true, null },
                    { 11, "GC-1144-6576", 2, true, null },
                    { 12, "GC-8112-2748", 2, true, null },
                    { 13, "GC-0206-5299", 2, false, null },
                    { 14, "GC-7971-0469", 2, false, null },
                    { 15, "GC-6227-0804", 2, false, null },
                    { 16, "GC-4663-1504", 2, false, null },
                    { 17, "GC-8097-6446", 2, false, null },
                    { 18, "GC-2589-3205", 2, false, null },
                    { 19, "GC-3999-1479", 2, false, null },
                    { 20, "GC-1787-6307", 2, false, null },
                    { 21, "GC-6086-4255", 3, false, null },
                    { 22, "GC-0816-2239", 3, false, null },
                    { 23, "GC-1542-4776", 3, false, null },
                    { 24, "GC-3211-1940", 3, true, null },
                    { 25, "GC-5951-1607", 3, false, null },
                    { 26, "GC-3784-6406", 3, true, null },
                    { 27, "GC-2914-5383", 3, false, null },
                    { 28, "GC-1253-4962", 3, false, null },
                    { 29, "GC-2673-9862", 3, false, null },
                    { 30, "GC-5209-1128", 3, false, null },
                    { 31, "GC-0178-2071", 4, false, null },
                    { 32, "GC-5172-9368", 4, false, null },
                    { 33, "GC-2399-5467", 4, false, null },
                    { 34, "GC-1245-9727", 4, false, null },
                    { 35, "GC-0459-2393", 4, true, null },
                    { 36, "GC-2579-0543", 4, false, null },
                    { 37, "GC-7004-2594", 4, false, null },
                    { 38, "GC-1392-6195", 4, false, null },
                    { 39, "GC-4960-7658", 4, false, null },
                    { 40, "GC-0400-9546", 4, false, null },
                    { 41, "GC-7134-3024", 5, true, null },
                    { 42, "GC-6797-8992", 5, false, null },
                    { 43, "GC-0011-3182", 5, true, null },
                    { 44, "GC-1424-6762", 5, false, null },
                    { 45, "GC-2082-0902", 5, false, null },
                    { 46, "GC-5922-5617", 5, false, null },
                    { 47, "GC-6641-3831", 5, true, null },
                    { 48, "GC-6511-3784", 5, false, null },
                    { 49, "GC-0629-2899", 5, true, null },
                    { 50, "GC-1793-2091", 5, false, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "GiftcardCodeId", "PaymentStatus", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 13, 13, 34, 59, 814, DateTimeKind.Unspecified).AddTicks(832), null, 0, 4 },
                    { 2, new DateTime(2016, 6, 18, 15, 49, 17, 948, DateTimeKind.Unspecified).AddTicks(4618), null, 0, 5 },
                    { 3, new DateTime(2021, 1, 9, 7, 35, 12, 731, DateTimeKind.Unspecified).AddTicks(9587), null, 0, 2 },
                    { 4, new DateTime(2020, 4, 10, 20, 24, 40, 203, DateTimeKind.Unspecified).AddTicks(272), null, 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Autem occaecati voluptas ipsa sed rerum eveniet repellat fuga.", 4, 1, 6 },
                    { 2, "Accusamus ratione eveniet veritatis quos quia corrupti eveniet.", 4, 4, 6 },
                    { 3, "Laudantium sint officiis maiores quaerat voluptate odit qui.", 3, 5, 4 },
                    { 4, "Cum consequatur et earum neque voluptatem tempore optio.", 4, 4, 6 },
                    { 5, "Voluptates dolor architecto et vel mollitia voluptas sapiente.", 4, 3, 6 },
                    { 6, "Consequatur nihil et sit dolorem consequatur iusto nam cumque animi.", 2, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 11, 2, 1 },
                    { 2, 13, 4, 6 },
                    { 3, 18, 5, 1 },
                    { 4, 11, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "GenreBooks",
                columns: new[] { "Id", "BookId", "GenreId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 1, 3, false },
                    { 2, 1, 5, true },
                    { 3, 2, 5, false },
                    { 4, 2, 4, true },
                    { 5, 3, 3, true },
                    { 6, 3, 2, false },
                    { 7, 4, 3, false },
                    { 8, 4, 1, true },
                    { 9, 4, 7, false },
                    { 10, 5, 6, true },
                    { 11, 6, 3, false },
                    { 12, 6, 8, true },
                    { 13, 7, 4, false },
                    { 14, 7, 2, true },
                    { 15, 8, 7, false },
                    { 16, 8, 5, true },
                    { 17, 8, 1, false },
                    { 18, 9, 3, true },
                    { 19, 10, 5, true },
                    { 20, 10, 8, false },
                    { 21, 10, 4, false },
                    { 22, 11, 8, true },
                    { 23, 11, 7, false },
                    { 24, 11, 6, false },
                    { 25, 12, 5, true },
                    { 26, 13, 4, true },
                    { 27, 13, 1, false },
                    { 28, 14, 4, false },
                    { 29, 14, 3, true },
                    { 30, 15, 8, true },
                    { 31, 16, 5, true },
                    { 32, 17, 7, false },
                    { 33, 17, 2, true },
                    { 34, 18, 6, false },
                    { 35, 18, 4, true },
                    { 36, 18, 2, false },
                    { 37, 19, 7, true },
                    { 38, 20, 4, true },
                    { 39, 21, 4, true },
                    { 40, 21, 8, false },
                    { 41, 21, 3, false },
                    { 42, 22, 7, true },
                    { 43, 22, 3, false },
                    { 44, 23, 7, false },
                    { 45, 23, 3, true },
                    { 46, 23, 5, false },
                    { 47, 24, 2, true },
                    { 48, 25, 1, false },
                    { 49, 25, 7, true },
                    { 50, 26, 3, false },
                    { 51, 26, 6, true },
                    { 52, 27, 4, true },
                    { 53, 27, 5, false },
                    { 54, 27, 6, false },
                    { 55, 28, 4, true },
                    { 56, 29, 2, false },
                    { 57, 29, 5, true },
                    { 58, 30, 2, false },
                    { 59, 30, 7, true },
                    { 60, 31, 3, true },
                    { 61, 32, 6, false },
                    { 62, 32, 8, false },
                    { 63, 32, 5, true }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookAuthor", "BookISBN", "BookPrice", "BookPublisher", "BookTitle", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, "HollyHintz", "9440463495028", 14.81m, "Schiller, Rempel and Wiegand", "Dolor quidem illum saepe unde eum.", 1, 3 },
                    { 2, "DesmondWalker", "9674587729237", 10.69m, "Koch Inc", "Ducimus non accusantium exercitationem recusandae.", 1, 3 },
                    { 3, "WestleyHayes", "5540797888412", 14.88m, "Rolfson, Klein and Smitham", "Quibusdam harum vitae saepe eveniet quo.", 2, 5 },
                    { 4, "JammieUllrich", "9674587729237", 10.69m, "Jacobson, Nikolaus and Miller", "Ducimus non accusantium exercitationem recusandae.", 3, 4 },
                    { 5, "D'angeloRunolfsson", "7558108623988", 10.63m, "O'Kon, Medhurst and Schimmel", "Magnam nobis similique aperiam doloremque.", 4, 3 },
                    { 6, "RayDooley", "1330847226899", 19.77m, "Hettinger - Koch", "Et id quaerat praesentium architecto.", 4, 5 }
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
