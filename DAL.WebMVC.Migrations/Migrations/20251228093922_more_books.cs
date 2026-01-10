using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
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
                    NormalizedName = table.Column<string>(
                        type: "TEXT",
                        maxLength: 256,
                        nullable: true
                    ),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Giftcard",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giftcard", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsBanned = table.Column<bool>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(
                        type: "TEXT",
                        maxLength: 256,
                        nullable: true
                    ),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(
                        type: "TEXT",
                        maxLength: 256,
                        nullable: true
                    ),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverImageName = table.Column<string>(type: "TEXT", nullable: true),
                    EditCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LastEditedById = table.Column<int>(type: "INTEGER", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Book_User_LastEditedById",
                        column: x => x.LastEditedById,
                        principalTable: "User",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserLogins",
                        x => new { x.LoginProvider, x.ProviderKey }
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserTokens",
                        x => new
                        {
                            x.UserId,
                            x.LoginProvider,
                            x.Name,
                        }
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "BookReview",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReview_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_BookReview_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CartItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "GenreBooks",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_GenreBooks_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "WishlistItem",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_WishlistItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "GiftcardCode",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GiftcardId = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftcardCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftcardCode_Giftcard_GiftcardId",
                        column: x => x.GiftcardId,
                        principalTable: "Giftcard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GiftcardCodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_GiftcardCode_GiftcardCodeId",
                        column: x => x.GiftcardCodeId,
                        principalTable: "GiftcardCode",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookTitle = table.Column<string>(type: "TEXT", nullable: false),
                    BookISBN = table.Column<string>(type: "TEXT", nullable: false),
                    BookPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    BookPublisher = table.Column<string>(type: "TEXT", nullable: false),
                    BookAuthor = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Martin", "Mitchell" },
                    { 2, "Chaz", "Schaden" },
                    { 3, "Abbie", "Stokes" },
                    { 4, "Gerald", "Kunze" },
                    { 5, "Valentine", "Bosco" },
                }
            );

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
                    { 8, "Adventure" },
                }
            );

            migrationBuilder.InsertData(
                table: "Giftcard",
                columns: new[] { "Id", "Amount", "Name", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    {
                        1,
                        2000m,
                        "Incredible Cotton Tuna",
                        new DateTime(2024, 8, 10, 11, 6, 3, 873, DateTimeKind.Unspecified).AddTicks(
                            4863
                        ),
                        new DateTime(2025, 7, 10, 11, 6, 3, 873, DateTimeKind.Unspecified).AddTicks(
                            4863
                        ),
                    },
                    {
                        2,
                        500m,
                        "Ergonomic Steel Cheese",
                        new DateTime(
                            2024,
                            12,
                            12,
                            0,
                            5,
                            50,
                            172,
                            DateTimeKind.Unspecified
                        ).AddTicks(1048),
                        new DateTime(2026, 1, 12, 0, 5, 50, 172, DateTimeKind.Unspecified).AddTicks(
                            1048
                        ),
                    },
                    {
                        3,
                        2000m,
                        "Rustic Steel Gloves",
                        new DateTime(
                            2025,
                            2,
                            24,
                            3,
                            29,
                            32,
                            986,
                            DateTimeKind.Unspecified
                        ).AddTicks(1481),
                        new DateTime(
                            2025,
                            8,
                            24,
                            3,
                            29,
                            32,
                            986,
                            DateTimeKind.Unspecified
                        ).AddTicks(1481),
                    },
                    {
                        4,
                        500m,
                        "Fantastic Wooden Computer",
                        new DateTime(
                            2023,
                            12,
                            29,
                            11,
                            16,
                            34,
                            322,
                            DateTimeKind.Unspecified
                        ).AddTicks(5729),
                        new DateTime(
                            2025,
                            6,
                            29,
                            11,
                            16,
                            34,
                            322,
                            DateTimeKind.Unspecified
                        ).AddTicks(5729),
                    },
                    {
                        5,
                        250m,
                        "Rustic Concrete Table",
                        new DateTime(
                            2024,
                            10,
                            23,
                            9,
                            8,
                            39,
                            408,
                            DateTimeKind.Unspecified
                        ).AddTicks(6781),
                        new DateTime(2025, 7, 23, 9, 8, 39, 408, DateTimeKind.Unspecified).AddTicks(
                            6781
                        ),
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beatty, Will and Schaefer" },
                    { 2, "Jacobson - O'Keefe" },
                    { 3, "Treutel, Kertzmann and O'Hara" },
                    { 4, "Reynolds Inc" },
                }
            );

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
                    { 1, "Maye.Schaden@yahoo.com", false, "Elwin_Wisozk" },
                    { 2, "Brenna_Kiehn18@yahoo.com", false, "Jay_Koepp63" },
                    { 3, "Ciara.Ratke@gmail.com", false, "Laurie.Bednar0" },
                    { 4, "Janessa46@hotmail.com", false, "Ray73" },
                    { 5, "Rae76@gmail.com", false, "Abel_Kub6" },
                    { 6, "Laurine.Breitenberg@gmail.com", false, "Kris94" },
                    { 7, "Electa_Corkery15@hotmail.com", false, "Dedric_Jacobi" },
                    { 8, "Hillard16@gmail.com", false, "Margaret75" },
                }
            );

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[]
                {
                    "Id",
                    "AuthorId",
                    "CoverImageName",
                    "Description",
                    "EditCount",
                    "ISBN",
                    "LastEditedById",
                    "Price",
                    "PublisherId",
                    "Title",
                },
                values: new object[,]
                {
                    {
                        1,
                        2,
                        null,
                        "Quas aut quae in quidem. Ut similique esse voluptates quia perferendis sequi. Architecto libero voluptatem magni atque facilis officiis. Explicabo praesentium ea. Blanditiis facilis magni dolores illo quia. Nobis et et.",
                        9,
                        "2633772601366",
                        3,
                        18.08m,
                        4,
                        "Voluptas doloremque corporis in qui molestiae.",
                    },
                    {
                        2,
                        3,
                        null,
                        "Amet repellendus voluptas. Suscipit voluptas ipsa inventore id ab rerum. Quibusdam magni omnis. Fuga neque asperiores dolor. Fugit reprehenderit mollitia aut deserunt earum doloribus laborum quibusdam. Accusantium sit et adipisci et non sequi vitae doloremque aut.",
                        9,
                        "1556505264229",
                        5,
                        15.72m,
                        4,
                        "Quis id vero est vel deleniti.",
                    },
                    {
                        3,
                        1,
                        null,
                        "Qui aperiam blanditiis. Odio aut quas fugiat est at. Sunt consequatur qui alias in ut. Tempore sit aut saepe ex animi.",
                        2,
                        "7050936015565",
                        5,
                        13.77m,
                        2,
                        "Sed dolores quia non sint nam.",
                    },
                    {
                        4,
                        4,
                        null,
                        "Officia repellat est voluptatum tempore officia consequuntur. Vero cum natus velit dolor blanditiis adipisci nihil omnis. Cum nam et aut suscipit nemo tempora. Ea quia non voluptas iste et.",
                        8,
                        "2423833341887",
                        5,
                        16.74m,
                        1,
                        "Nemo aliquid explicabo consequatur eum incidunt.",
                    },
                    {
                        5,
                        1,
                        null,
                        "Itaque iste consequatur iure distinctio consectetur. Necessitatibus repellendus dolor. Accusantium tempore ea dignissimos laborum adipisci. Porro in totam.",
                        10,
                        "2994701900746",
                        3,
                        8.81m,
                        1,
                        "Ipsa aut dolor vitae placeat facilis.",
                    },
                    {
                        6,
                        4,
                        null,
                        "Tenetur ut occaecati aspernatur cupiditate aliquam enim consequatur nihil nostrum. Qui harum inventore maiores quia quis quia rem quo. Dolor velit quia tempore odit impedit eligendi. Exercitationem unde eaque velit voluptatibus nobis distinctio voluptates a.",
                        2,
                        "5355940209507",
                        3,
                        18.31m,
                        1,
                        "Voluptas ut consequuntur qui molestias.",
                    },
                    {
                        7,
                        5,
                        null,
                        "Similique maxime harum quidem voluptas eligendi. Provident eum esse quis nesciunt exercitationem. Enim voluptatem repellendus nobis molestiae. Dolores dignissimos architecto repellendus saepe tempore optio non. Ut corporis amet neque.",
                        6,
                        "1198983990032",
                        4,
                        14.85m,
                        2,
                        "Ex odio adipisci nostrum ullam doloribus.",
                    },
                    {
                        8,
                        1,
                        null,
                        "Ut ea debitis nisi ipsam voluptatem qui. Doloremque quia tempore rem. Aliquam explicabo cumque minima.",
                        6,
                        "6930024369248",
                        3,
                        7.21m,
                        2,
                        "Enim similique similique aspernatur.",
                    },
                    {
                        9,
                        3,
                        null,
                        "Dolor at minus ut et incidunt est. Animi repellendus esse sed aspernatur tempora omnis. Optio veniam optio ullam explicabo repellat id. Quaerat repellendus qui at similique sunt.",
                        10,
                        "9834877727095",
                        3,
                        14.04m,
                        3,
                        "Nulla et doloribus aliquid.",
                    },
                    {
                        10,
                        1,
                        null,
                        "Et quia quaerat eum officia magni sit. Corporis quasi atque cupiditate. Corrupti labore rem recusandae. Facilis minima veritatis ducimus dolorem voluptatum qui aut et. Dolor ratione voluptatem dolorem et tempora. Facilis perspiciatis temporibus voluptas quis.",
                        4,
                        "4077748941793",
                        1,
                        13.92m,
                        4,
                        "Ratione ipsam maxime voluptatem.",
                    },
                    {
                        11,
                        2,
                        null,
                        "Tempora labore sint voluptatum quod et a. Itaque quisquam asperiores et saepe dolorem tenetur fuga ab beatae. Incidunt quasi assumenda omnis qui aut saepe accusantium a. Ducimus aliquam hic ullam. Nulla sunt iure est vitae dolorum voluptas.",
                        7,
                        "0735021712044",
                        5,
                        19.01m,
                        4,
                        "Voluptatem molestias nisi et.",
                    },
                    {
                        12,
                        5,
                        null,
                        "Voluptatibus nulla voluptatum modi nulla porro commodi rerum veritatis et. Rem soluta ut quasi quod ea. Autem ut aspernatur reiciendis quo dicta eos nostrum.",
                        0,
                        "7328793021440",
                        4,
                        14.35m,
                        3,
                        "Quia non eos rem.",
                    },
                    {
                        13,
                        4,
                        null,
                        "Possimus nemo dolorem veniam nihil modi voluptas dignissimos molestias voluptas. Recusandae quia nam sint quasi sapiente laudantium enim. Voluptates qui iusto dolorum non similique error harum sint nostrum.",
                        5,
                        "3933622629847",
                        3,
                        15.91m,
                        3,
                        "Incidunt architecto dicta impedit a.",
                    },
                    {
                        14,
                        5,
                        null,
                        "Rem quia autem eligendi ut vero maxime repellat. Asperiores inventore quasi. Fuga aut sint facilis. Sunt commodi dicta placeat aut veniam pariatur autem sit magnam. Dolores recusandae rerum pariatur dolores quas. Occaecati saepe temporibus.",
                        7,
                        "3202189729049",
                        2,
                        18.79m,
                        4,
                        "Enim nemo eius ex architecto vel.",
                    },
                    {
                        15,
                        3,
                        null,
                        "Quia est accusamus et eum. Ea maiores quis. Enim labore quis sit aspernatur autem aspernatur. Quidem cupiditate ea quidem labore nulla nemo.",
                        8,
                        "3323554465093",
                        2,
                        6.69m,
                        1,
                        "Quibusdam ullam autem cupiditate.",
                    },
                    {
                        16,
                        5,
                        null,
                        "Neque ducimus nostrum sint dolore et. Tempora nesciunt laboriosam voluptatem amet aut voluptas. Error nam eaque soluta aut. Aut sed ut. Nihil eius voluptatem accusantium enim.",
                        6,
                        "4606592610366",
                        3,
                        15.32m,
                        1,
                        "Delectus quae animi quod.",
                    },
                    {
                        17,
                        5,
                        null,
                        "Eos distinctio et ut iste quia iure est voluptatem ut. Possimus et corporis ipsum ut debitis maxime quaerat. Dolores ducimus blanditiis nam assumenda eligendi et. Nihil consequatur qui voluptas sed neque. Commodi velit eum enim ipsam suscipit repudiandae aut doloribus.",
                        4,
                        "0641957664985",
                        4,
                        17.36m,
                        1,
                        "Consequatur laboriosam distinctio tempore incidunt aliquid.",
                    },
                    {
                        18,
                        1,
                        null,
                        "Dolores libero velit ut unde quaerat ea. Reiciendis officiis voluptatem possimus omnis et quod porro excepturi quia. Dolor tempore sit rem quas cum ducimus voluptates. Vitae libero quia est autem qui culpa dolor similique. Rerum et qui. Accusantium cum natus labore aut magni tempore quasi explicabo.",
                        0,
                        "7424020270732",
                        4,
                        17.20m,
                        2,
                        "Eos hic est quas ad.",
                    },
                    {
                        19,
                        2,
                        null,
                        "Totam et quia optio repudiandae veniam repellendus doloribus eum. Minima repellat quasi eos quam ex. Esse et quia id occaecati nihil omnis.",
                        2,
                        "1166827784048",
                        5,
                        13.53m,
                        2,
                        "Et explicabo repudiandae saepe nam quas.",
                    },
                    {
                        20,
                        3,
                        null,
                        "Suscipit voluptatem cum aut ullam voluptate. Molestias dignissimos eos. Est inventore laborum temporibus voluptatem aut. Veritatis maiores iusto ut.",
                        4,
                        "0420025092819",
                        2,
                        17.61m,
                        4,
                        "Delectus tempore necessitatibus rerum.",
                    },
                    {
                        21,
                        5,
                        null,
                        "Dolores tenetur neque ullam id quo sint aut. Aut ea adipisci debitis at. Qui iusto molestias atque voluptas facere labore fugit rem.",
                        8,
                        "2058845892692",
                        2,
                        9.84m,
                        4,
                        "Consectetur voluptate id velit repellendus.",
                    },
                    {
                        22,
                        3,
                        null,
                        "Harum quasi excepturi odit asperiores. Assumenda est impedit dolorem. Eveniet autem perspiciatis repellat aliquam. Possimus vero nesciunt rerum rerum.",
                        1,
                        "9620745963548",
                        3,
                        12.23m,
                        4,
                        "Corrupti iure nesciunt at molestiae dolores.",
                    },
                    {
                        23,
                        2,
                        null,
                        "Quaerat et voluptas culpa. Et perspiciatis qui ut repudiandae aut ut voluptas quod. Animi vel non placeat consequuntur iste quo numquam nihil nihil. Excepturi unde necessitatibus. Dicta reprehenderit est deserunt quo enim sint inventore. Qui aut necessitatibus placeat eos et sit illum dolores consequatur.",
                        2,
                        "3214459478038",
                        1,
                        6.38m,
                        4,
                        "Consequatur eum itaque iure eveniet omnis.",
                    },
                    {
                        24,
                        5,
                        null,
                        "Magni et dolorem veniam. Aliquam animi corporis quae recusandae cum ab ut totam facere. Quo et commodi laboriosam recusandae voluptate dolor est sunt dolores. Occaecati officiis minus iure doloribus quia ducimus et alias ipsa. Error cupiditate tempore est non aliquam qui et. Non necessitatibus eos.",
                        0,
                        "7927578431346",
                        3,
                        15.36m,
                        1,
                        "Quod incidunt non est dolores.",
                    },
                    {
                        25,
                        2,
                        null,
                        "Et provident consectetur quo impedit animi eum iusto. Magnam dolorem dolores reprehenderit natus sit nemo rerum illo. Ad reprehenderit ex.",
                        4,
                        "4891758830102",
                        5,
                        13.68m,
                        1,
                        "Temporibus possimus esse sit.",
                    },
                    {
                        26,
                        2,
                        null,
                        "Est voluptate nam ipsa nesciunt delectus. Voluptatibus ut exercitationem tenetur facilis omnis. Vitae omnis et sit eveniet eius quam. Consequatur voluptas totam saepe soluta consectetur culpa natus.",
                        0,
                        "5941192228139",
                        1,
                        8.25m,
                        2,
                        "Ducimus exercitationem ea nemo quas.",
                    },
                    {
                        27,
                        2,
                        null,
                        "Eligendi est mollitia neque ex eius dolores sint et vitae. Aliquam eum ut earum odio. Accusantium beatae ex dolorem non. Excepturi ratione exercitationem.",
                        1,
                        "3384842831990",
                        1,
                        11.56m,
                        3,
                        "Voluptatum illum hic et sequi.",
                    },
                    {
                        28,
                        2,
                        null,
                        "Quas sit non qui modi. Aspernatur nisi autem id qui explicabo nemo accusantium quas. Temporibus est consequuntur sed ut quod eveniet. Omnis et cupiditate necessitatibus voluptatibus et.",
                        5,
                        "5527244905243",
                        3,
                        9.25m,
                        3,
                        "Quia exercitationem repellat natus iusto aspernatur.",
                    },
                    {
                        29,
                        2,
                        null,
                        "Quibusdam delectus aspernatur est reiciendis. Dignissimos minima rem tenetur sapiente sunt. Et earum in occaecati voluptatem non enim neque explicabo.",
                        0,
                        "4477794296487",
                        2,
                        17.12m,
                        4,
                        "Occaecati accusantium tenetur sunt delectus.",
                    },
                    {
                        30,
                        5,
                        null,
                        "Quasi ut quaerat molestias explicabo ipsa laudantium. Commodi est et. Aspernatur nam ut facilis temporibus est voluptate amet.",
                        7,
                        "0236250408239",
                        2,
                        14.32m,
                        3,
                        "Et cum laborum ullam amet et.",
                    },
                    {
                        31,
                        1,
                        null,
                        "Sit laborum necessitatibus aut non sit voluptas. Asperiores et sint odio autem praesentium id. Quo asperiores tempore perspiciatis perspiciatis non soluta nam. Itaque omnis et similique culpa ipsam voluptatem. Suscipit at et in eveniet voluptatem.",
                        10,
                        "4348480798977",
                        4,
                        17.06m,
                        3,
                        "Est cum alias rerum cupiditate nihil.",
                    },
                    {
                        32,
                        2,
                        null,
                        "Voluptates sed dolor aut. Labore et consequatur voluptas pariatur. Dolores sed totam nostrum omnis sed eligendi. Eius non enim voluptate repellendus dolorum pariatur.",
                        3,
                        "8770685595734",
                        5,
                        6.79m,
                        4,
                        "Consequatur distinctio et ullam magni voluptas.",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "GiftcardCode",
                columns: new[] { "Id", "Code", "GiftcardId", "IsUsed", "OrderId" },
                values: new object[,]
                {
                    { 1, "GC-4313-4688", 1, false, null },
                    { 2, "GC-8004-3644", 1, false, null },
                    { 3, "GC-3438-6695", 1, false, null },
                    { 4, "GC-7309-1345", 1, false, null },
                    { 5, "GC-7928-5627", 1, false, null },
                    { 6, "GC-6972-1888", 1, false, null },
                    { 7, "GC-1168-4489", 1, true, null },
                    { 8, "GC-0851-2990", 1, false, null },
                    { 9, "GC-2270-4085", 1, false, null },
                    { 10, "GC-0847-1836", 1, false, null },
                    { 11, "GC-4926-0554", 2, false, null },
                    { 12, "GC-4903-3269", 2, false, null },
                    { 13, "GC-6686-2481", 2, false, null },
                    { 14, "GC-4045-0101", 2, true, null },
                    { 15, "GC-0524-1280", 2, false, null },
                    { 16, "GC-4535-6998", 2, false, null },
                    { 17, "GC-1457-3675", 2, false, null },
                    { 18, "GC-9517-4796", 2, false, null },
                    { 19, "GC-2660-0228", 2, false, null },
                    { 20, "GC-9111-3375", 2, false, null },
                    { 21, "GC-0935-1889", 3, false, null },
                    { 22, "GC-1927-5596", 3, false, null },
                    { 23, "GC-7885-3570", 3, false, null },
                    { 24, "GC-0226-3316", 3, false, null },
                    { 25, "GC-0389-2112", 3, false, null },
                    { 26, "GC-0553-7168", 3, false, null },
                    { 27, "GC-6458-5765", 3, true, null },
                    { 28, "GC-6070-8950", 3, false, null },
                    { 29, "GC-7395-4673", 3, false, null },
                    { 30, "GC-8762-4361", 3, false, null },
                    { 31, "GC-8611-0202", 4, true, null },
                    { 32, "GC-5952-8573", 4, false, null },
                    { 33, "GC-2617-7487", 4, true, null },
                    { 34, "GC-1398-0131", 4, false, null },
                    { 35, "GC-2335-4185", 4, true, null },
                    { 36, "GC-5371-4100", 4, false, null },
                    { 37, "GC-3905-3862", 4, true, null },
                    { 38, "GC-7933-8832", 4, false, null },
                    { 39, "GC-1429-1135", 4, false, null },
                    { 40, "GC-7501-9257", 4, false, null },
                    { 41, "GC-8875-5602", 5, false, null },
                    { 42, "GC-6564-0991", 5, false, null },
                    { 43, "GC-5134-9575", 5, false, null },
                    { 44, "GC-5603-0526", 5, false, null },
                    { 45, "GC-5324-8267", 5, false, null },
                    { 46, "GC-9027-1365", 5, false, null },
                    { 47, "GC-1847-5811", 5, false, null },
                    { 48, "GC-9692-1341", 5, false, null },
                    { 49, "GC-0994-3815", 5, false, null },
                    { 50, "GC-3266-3620", 5, false, null },
                }
            );

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "GiftcardCodeId", "PaymentStatus", "UserId" },
                values: new object[,]
                {
                    {
                        1,
                        new DateTime(
                            2021,
                            10,
                            29,
                            10,
                            23,
                            6,
                            711,
                            DateTimeKind.Unspecified
                        ).AddTicks(7354),
                        null,
                        0,
                        8,
                    },
                    {
                        2,
                        new DateTime(
                            2025,
                            8,
                            19,
                            10,
                            32,
                            4,
                            342,
                            DateTimeKind.Unspecified
                        ).AddTicks(802),
                        null,
                        0,
                        2,
                    },
                    {
                        3,
                        new DateTime(
                            2020,
                            11,
                            11,
                            5,
                            2,
                            58,
                            202,
                            DateTimeKind.Unspecified
                        ).AddTicks(4940),
                        null,
                        0,
                        5,
                    },
                    {
                        4,
                        new DateTime(
                            2018,
                            7,
                            30,
                            1,
                            54,
                            29,
                            352,
                            DateTimeKind.Unspecified
                        ).AddTicks(5402),
                        null,
                        0,
                        1,
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Ab recusandae vero temporibus unde quam a autem autem.", 1, 3, 8 },
                    { 2, "Repellat voluptatem et ipsa aut labore ducimus et.", 3, 1, 7 },
                    {
                        3,
                        "Ut voluptas nisi accusamus ea quas sed omnis blanditiis iusto.",
                        3,
                        2,
                        1,
                    },
                    { 4, "Dolores velit illo suscipit sit expedita quis amet molestiae.", 4, 5, 8 },
                    { 5, "Perferendis culpa ut fuga culpa sint quo voluptatem.", 1, 3, 1 },
                    { 6, "Id ad cupiditate possimus rerum ut a qui molestiae.", 2, 5, 3 },
                }
            );

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 20, 4, 7 },
                    { 2, 26, 2, 7 },
                    { 3, 22, 5, 2 },
                    { 4, 2, 4, 6 },
                }
            );

            migrationBuilder.InsertData(
                table: "GenreBooks",
                columns: new[] { "Id", "BookId", "GenreId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 1, 7, true },
                    { 2, 2, 4, true },
                    { 3, 3, 2, true },
                    { 4, 3, 1, false },
                    { 5, 3, 7, false },
                    { 6, 4, 2, true },
                    { 7, 5, 5, false },
                    { 8, 5, 2, true },
                    { 9, 6, 1, false },
                    { 10, 6, 2, true },
                    { 11, 7, 1, true },
                    { 12, 7, 3, false },
                    { 13, 7, 2, false },
                    { 14, 8, 3, true },
                    { 15, 8, 5, false },
                    { 16, 8, 1, false },
                    { 17, 9, 7, false },
                    { 18, 9, 8, false },
                    { 19, 9, 6, true },
                    { 20, 10, 1, true },
                    { 21, 11, 8, true },
                    { 22, 11, 5, false },
                    { 23, 11, 7, false },
                    { 24, 12, 3, true },
                    { 25, 13, 5, true },
                    { 26, 13, 7, false },
                    { 27, 14, 5, true },
                    { 28, 15, 2, false },
                    { 29, 15, 1, true },
                    { 30, 16, 7, true },
                    { 31, 17, 7, false },
                    { 32, 17, 4, false },
                    { 33, 17, 8, true },
                    { 34, 18, 8, false },
                    { 35, 18, 4, true },
                    { 36, 19, 2, true },
                    { 37, 20, 1, true },
                    { 38, 21, 5, true },
                    { 39, 21, 2, false },
                    { 40, 22, 7, false },
                    { 41, 22, 4, false },
                    { 42, 22, 3, true },
                    { 43, 23, 2, false },
                    { 44, 23, 6, true },
                    { 45, 23, 3, false },
                    { 46, 24, 4, false },
                    { 47, 24, 7, true },
                    { 48, 25, 8, false },
                    { 49, 25, 6, true },
                    { 50, 26, 2, false },
                    { 51, 26, 5, true },
                    { 52, 27, 5, true },
                    { 53, 28, 8, true },
                    { 54, 29, 2, true },
                    { 55, 30, 8, false },
                    { 56, 30, 2, true },
                    { 57, 31, 7, false },
                    { 58, 31, 5, true },
                    { 59, 31, 4, false },
                    { 60, 32, 1, true },
                }
            );

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[]
                {
                    "Id",
                    "BookAuthor",
                    "BookISBN",
                    "BookPrice",
                    "BookPublisher",
                    "BookTitle",
                    "OrderId",
                    "Quantity",
                },
                values: new object[,]
                {
                    {
                        1,
                        "BeaulahBergstrom",
                        "3933622629847",
                        15.91m,
                        "Durgan, Ondricka and Mraz",
                        "Incidunt architecto dicta impedit a.",
                        1,
                        2,
                    },
                    {
                        2,
                        "ConorBergnaum",
                        "5355940209507",
                        18.31m,
                        "Schoen, Brakus and Pouros",
                        "Voluptas ut consequuntur qui molestias.",
                        1,
                        2,
                    },
                    {
                        3,
                        "RomaineKonopelski",
                        "9620745963548",
                        12.23m,
                        "Hickle Group",
                        "Corrupti iure nesciunt at molestiae dolores.",
                        2,
                        3,
                    },
                    {
                        4,
                        "AllenPollich",
                        "7328793021440",
                        14.35m,
                        "Bins - Doyle",
                        "Quia non eos rem.",
                        2,
                        5,
                    },
                    {
                        5,
                        "MarisolHaley",
                        "4891758830102",
                        13.68m,
                        "Bednar - King",
                        "Temporibus possimus esse sit.",
                        2,
                        5,
                    },
                    {
                        6,
                        "CandelarioCartwright",
                        "5941192228139",
                        8.25m,
                        "Feest Group",
                        "Ducimus exercitationem ea nemo quas.",
                        3,
                        2,
                    },
                    {
                        7,
                        "WarrenQuitzon",
                        "4348480798977",
                        17.06m,
                        "Wiza, Von and Roberts",
                        "Est cum alias rerum cupiditate nihil.",
                        4,
                        3,
                    },
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Book_LastEditedById",
                table: "Book",
                column: "LastEditedById"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_BookId",
                table: "BookReview",
                column: "BookId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_UserId",
                table: "BookReview",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BookId",
                table: "CartItem",
                column: "BookId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_UserId",
                table: "CartItem",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_BookId_IsPrimary",
                table: "GenreBooks",
                columns: new[] { "BookId", "IsPrimary" },
                unique: true,
                filter: "[IsPrimary] = 1"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_GenreId",
                table: "GenreBooks",
                column: "GenreId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GiftcardCode_GiftcardId",
                table: "GiftcardCode",
                column: "GiftcardId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GiftcardCode_OrderId",
                table: "GiftcardCode",
                column: "OrderId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Order_GiftcardCodeId",
                table: "Order",
                column: "GiftcardCodeId"
            );

            migrationBuilder.CreateIndex(name: "IX_Order_UserId", table: "Order", column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_BookId",
                table: "WishlistItem",
                column: "BookId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_UserId",
                table: "WishlistItem",
                column: "UserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_GiftcardCode_Order_OrderId",
                table: "GiftcardCode",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Order_User_UserId", table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftcardCode_Giftcard_GiftcardId",
                table: "GiftcardCode"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_GiftcardCode_Order_OrderId",
                table: "GiftcardCode"
            );

            migrationBuilder.DropTable(name: "AspNetRoleClaims");

            migrationBuilder.DropTable(name: "AspNetUserClaims");

            migrationBuilder.DropTable(name: "AspNetUserLogins");

            migrationBuilder.DropTable(name: "AspNetUserRoles");

            migrationBuilder.DropTable(name: "AspNetUserTokens");

            migrationBuilder.DropTable(name: "BookReview");

            migrationBuilder.DropTable(name: "CartItem");

            migrationBuilder.DropTable(name: "GenreBooks");

            migrationBuilder.DropTable(name: "OrderItem");

            migrationBuilder.DropTable(name: "WishlistItem");

            migrationBuilder.DropTable(name: "AspNetRoles");

            migrationBuilder.DropTable(name: "AspNetUsers");

            migrationBuilder.DropTable(name: "Genre");

            migrationBuilder.DropTable(name: "Book");

            migrationBuilder.DropTable(name: "Author");

            migrationBuilder.DropTable(name: "Publisher");

            migrationBuilder.DropTable(name: "User");

            migrationBuilder.DropTable(name: "Giftcard");

            migrationBuilder.DropTable(name: "Order");

            migrationBuilder.DropTable(name: "GiftcardCode");
        }
    }
}
