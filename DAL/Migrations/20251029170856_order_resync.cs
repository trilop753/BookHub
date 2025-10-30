using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class order_resync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
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
                    { 1, "Jermey", "Lehner" },
                    { 2, "Pascale", "Spencer" },
                    { 3, "Vivianne", "O'Reilly" },
                    { 4, "Arvid", "Wolff" },
                    { 5, "Hermina", "Prosacco" }
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
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Schroeder, Stoltenberg and Shanahan" },
                    { 2, "Torp - Tromp" },
                    { 3, "Jacobi, Tillman and Jones" },
                    { 4, "Hudson LLC" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
                    { 1, "Estrella57@gmail.com", false, "Terrill57" },
                    { 2, "Dennis.Kuhn49@yahoo.com", false, "Myrna_OKon" },
                    { 3, "Filomena.Morar@hotmail.com", true, "Emanuel72" },
                    { 4, "Godfrey.Jaskolski@gmail.com", false, "Neva.Treutel97" },
                    { 5, "Alford.Fisher@yahoo.com", false, "Madaline_Osinski" },
                    { 6, "Santiago.Kemmer80@yahoo.com", false, "Lessie.Turcotte24" },
                    { 7, "Manuela_Fay@yahoo.com", false, "Rachelle88" },
                    { 8, "Joany_Corwin1@gmail.com", false, "Aaron.Streich24" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 5, "Omnis modi magnam dolores voluptas. Et officiis sed voluptas odit facere quam. Odit doloremque dignissimos et. Omnis et est. Deserunt corporis molestiae quasi consequuntur. Dignissimos ab aspernatur asperiores est.", "6990281470026", 7.71m, 3, "Qui provident saepe quam cum perferendis." },
                    { 2, 2, "Assumenda et quia et et iste. A ea ut vel quod maxime rem dolorem qui. Excepturi et at. Consequatur et autem repudiandae.", "3695979644170", 19.06m, 4, "Ut cupiditate a consectetur repellat eos." },
                    { 3, 2, "Vero quidem et. Ad natus qui. Autem qui rerum eos et. Eos sunt quo odit sapiente expedita expedita cumque et. Odit quo tenetur eveniet dolorum. Officiis inventore dolore harum quo rerum corrupti.", "1380438581388", 13.31m, 2, "Mollitia consequatur maiores velit minus cum." },
                    { 4, 5, "Aut quasi officiis vel beatae. Ea doloremque itaque voluptatibus officiis nisi omnis. Architecto exercitationem molestiae temporibus. Error quibusdam et quod est non rerum quae et tempora. Dicta dolorum dolorum magni possimus dolore quam dolor et. Veritatis ducimus nemo id autem.", "2239462964584", 13.80m, 3, "Et et et accusantium." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2017, 1, 14, 1, 49, 36, 113, DateTimeKind.Unspecified).AddTicks(3304), 5 },
                    { 2, new DateTime(2017, 6, 22, 12, 55, 59, 832, DateTimeKind.Unspecified).AddTicks(5418), 6 },
                    { 3, new DateTime(2016, 8, 12, 22, 8, 47, 586, DateTimeKind.Unspecified).AddTicks(287), 4 },
                    { 4, new DateTime(2024, 6, 7, 9, 11, 10, 671, DateTimeKind.Unspecified).AddTicks(1508), 8 }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Sed odio consequatur ratione ut velit est totam eum.", 4, 4, 8 },
                    { 2, "Laboriosam rerum iure distinctio ut aliquid reprehenderit suscipit.", 4, 2, 6 },
                    { 3, "Nulla sit modi sit quos quo nisi dolore.", 1, 3, 6 },
                    { 4, "Nihil quis dolor magni est qui eos provident ipsam eum.", 3, 4, 5 },
                    { 5, "Qui nihil occaecati sed sit illum incidunt dicta totam dolor.", 1, 1, 4 },
                    { 6, "Et est aut fugit ea veniam eum modi possimus.", 3, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 3, 1, 1 },
                    { 2, 3, 3, 4 },
                    { 3, 3, 2, 3 },
                    { 4, 1, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 4 },
                    { 2, 4, 1, 4 },
                    { 3, 3, 1, 4 },
                    { 4, 4, 2, 4 },
                    { 5, 3, 2, 4 },
                    { 6, 3, 3, 4 },
                    { 7, 4, 4, 1 },
                    { 8, 2, 4, 3 },
                    { 9, 4, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "BookReview");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "WishlistItem");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
