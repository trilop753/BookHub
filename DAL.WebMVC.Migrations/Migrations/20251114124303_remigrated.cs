using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class remigrated : Migration
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
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    CoverImageUrl = table.Column<string>(type: "TEXT", nullable: true),
========
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
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
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, "Earnest", "Metz" },
                    { 2, "Adrian", "Willms" },
                    { 3, "Mara", "Quigley" },
                    { 4, "Ansel", "Haley" },
                    { 5, "Duane", "Nienow" }
========
                    { 1, "Ettie", "Ankunding" },
                    { 2, "Abdiel", "Crist" },
                    { 3, "Octavia", "Bode" },
                    { 4, "Nikko", "Lebsack" },
                    { 5, "Adalberto", "MacGyver" }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, "Dangelo", "Halvorson" },
                    { 2, "Elias", "Collins" },
                    { 3, "Ari", "Blick" },
                    { 4, "Lee", "Bayer" },
                    { 5, "Filomena", "Torp" }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
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
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, "Dietrich, Cormier and Pacocha" },
                    { 2, "Gibson, Roob and Grady" },
                    { 3, "Gaylord - Bosco" },
                    { 4, "Cummings, Lubowitz and Kulas" }
========
                    { 1, "Kuhlman and Sons" },
                    { 2, "Kutch, Schmeler and Carroll" },
                    { 3, "Hammes LLC" },
                    { 4, "Daugherty - Considine" }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, "Hilpert, Hyatt and Heidenreich" },
                    { 2, "Bahringer Group" },
                    { 3, "Rodriguez, Ankunding and Douglas" },
                    { 4, "Raynor, Watsica and Wehner" }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, "Jayde_Yundt91@hotmail.com", false, "Bernhard_Ratke" },
                    { 2, "Floyd_Moore@yahoo.com", false, "Molly38" },
                    { 3, "Jacky_Weissnat20@gmail.com", false, "Eugene_Marquardt75" },
                    { 4, "Chauncey.Sipes@gmail.com", false, "Laury.Little" },
                    { 5, "Antonio33@yahoo.com", false, "Kira.McKenzie" },
                    { 6, "Leonor12@gmail.com", false, "Vito_Dicki68" },
                    { 7, "Dorian8@hotmail.com", false, "Kiel_Smith" },
                    { 8, "Ford90@hotmail.com", false, "Ramiro64" }
========
                    { 1, "Assunta.Reilly7@hotmail.com", false, "Anita61" },
                    { 2, "Emory50@hotmail.com", false, "Ruth17" },
                    { 3, "Bria_Douglas2@yahoo.com", false, "Darlene.Ruecker20" },
                    { 4, "Khalid.Gaylord46@hotmail.com", false, "Fabiola.Robel47" },
                    { 5, "Dustin_Gorczany@hotmail.com", false, "Jaeden.Grant87" },
                    { 6, "Modesto_Friesen@yahoo.com", false, "Jermain81" },
                    { 7, "Demario.Metz38@gmail.com", false, "Eliseo.Hilpert36" },
                    { 8, "Claudia_Kutch90@hotmail.com", true, "Gaston1" }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, "Amara.Sawayn93@gmail.com", false, "Torrey_Pollich89" },
                    { 2, "Donnell98@gmail.com", false, "Preston52" },
                    { 3, "Raleigh_Howell16@yahoo.com", true, "Carmella_Pollich" },
                    { 4, "Junior21@yahoo.com", false, "Maegan51" },
                    { 5, "Gabe.Kuvalis@hotmail.com", false, "Jena.Boyer" },
                    { 6, "Kayla.Mills30@gmail.com", false, "Camilla_Yost" },
                    { 7, "Jerel_Hahn47@gmail.com", true, "Aglae.Beahan" },
                    { 8, "Nola_Zieme@gmail.com", false, "Breanne55" }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
                });

            migrationBuilder.InsertData(
                table: "Book",
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                columns: new[] { "Id", "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, 5, null, "Sed suscipit est ea consequuntur ducimus et culpa. Laudantium perspiciatis placeat. Nostrum officiis quia distinctio doloremque modi.", 3, "6047833501377", 2, 5.20m, 2, "Saepe ut iusto fugit aliquam." },
                    { 2, 1, null, "Deserunt doloribus voluptates est deleniti in deserunt maiores. Et autem at ratione. Excepturi pariatur architecto ea. Provident magnam alias ad facilis. Ex dignissimos suscipit voluptatem aut dolor quidem nihil doloribus quos.", 10, "3519362025622", 5, 11.13m, 1, "Omnis quaerat quaerat labore sit." },
                    { 3, 4, null, "Incidunt adipisci mollitia delectus. Reprehenderit nobis hic et. Qui exercitationem quae nihil quod porro corporis repellendus. Asperiores itaque iusto velit amet molestiae consequuntur dolores nulla.", 4, "8288025698118", 2, 18.38m, 1, "Hic et eius iste eos." },
                    { 4, 3, null, "Voluptate fugiat pariatur neque quis non. Ipsa iste eaque sed reiciendis quibusdam nulla aperiam. Asperiores error quasi doloremque sed dolorem. Mollitia ipsa sunt. Vel consectetur provident aut sunt officia soluta iure.", 7, "8678088193635", 3, 9.73m, 2, "Dolorem laboriosam tenetur provident et." }
========
                    { 1, 1, "Eos eius eligendi natus nemo. Vitae quis possimus incidunt. Vel vel sint. Libero ea nihil eum at eum cumque facilis ut. Totam facere deleniti et.", "9613120562412", 16.05m, 3, "Qui vel nesciunt nam voluptatem." },
                    { 2, 2, "Quam voluptatibus nostrum rerum ab et aut. Aut libero voluptatem deserunt. Laborum possimus ut aut libero voluptas quisquam totam quis.", "9968367676430", 12.03m, 4, "Assumenda dolorum distinctio et." },
                    { 3, 2, "Totam voluptatem iste. Beatae iusto dolor saepe et enim. Dolor rerum qui minus quia.", "3068705779239", 17.73m, 1, "Voluptatum vel saepe architecto perferendis enim." },
                    { 4, 5, "Consequuntur autem perspiciatis quo et odit iste quisquam ut. Et aspernatur ut enim est delectus sunt. Fugit quo et rerum et ducimus adipisci eveniet. Omnis explicabo pariatur aut magni nihil hic quae maxime quod.", "4333767004315", 15.14m, 1, "Quo nisi deserunt dolorem voluptatibus repellat." }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                columns: new[] { "Id", "AuthorId", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Dolores dolorem aut libero aut. Nobis nam qui velit ad quae veritatis mollitia qui. Quis sed aut maiores ut. Fuga repellendus illum. Eos rerum et quo nostrum.", 7, "0865097927292", 2, 8.07m, 3, "Eum amet ex fugiat." },
                    { 2, 5, "Incidunt voluptas hic dolor eum officia. Harum optio id nihil aut incidunt. Ducimus non unde a sequi.", 4, "5449690009651", 4, 11.80m, 2, "Non error molestiae mollitia corrupti." },
                    { 3, 4, "A nihil optio. Similique velit atque rem. Ut quia quidem. Sequi voluptatem praesentium aspernatur rerum quae rerum. Voluptas nemo aut minima et voluptate laudantium. Reiciendis provident hic.", 9, "9233516196467", 2, 17.47m, 2, "Minima omnis cupiditate dolores unde nobis." },
                    { 4, 3, "Quo doloremque aliquid in sit. Optio fuga recusandae laudantium consequatur itaque corrupti non aliquid et. Eos nobis deleniti perferendis reprehenderit. Fugiat blanditiis iste quia sunt.", 1, "9179114279099", 1, 11.25m, 3, "Sed temporibus accusamus modi voluptate." }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, new DateTime(2016, 6, 30, 11, 6, 21, 639, DateTimeKind.Unspecified).AddTicks(7192), 1 },
                    { 2, new DateTime(2019, 1, 24, 1, 12, 43, 650, DateTimeKind.Unspecified).AddTicks(715), 3 },
                    { 3, new DateTime(2019, 7, 19, 15, 12, 51, 716, DateTimeKind.Unspecified).AddTicks(4196), 4 },
                    { 4, new DateTime(2023, 8, 16, 0, 8, 43, 387, DateTimeKind.Unspecified).AddTicks(6816), 1 }
========
                    { 1, new DateTime(2023, 7, 4, 22, 36, 55, 849, DateTimeKind.Unspecified).AddTicks(1614), 1 },
                    { 2, new DateTime(2019, 10, 28, 13, 44, 52, 242, DateTimeKind.Unspecified).AddTicks(9150), 7 },
                    { 3, new DateTime(2022, 3, 23, 11, 44, 55, 630, DateTimeKind.Unspecified).AddTicks(1992), 5 },
                    { 4, new DateTime(2019, 4, 14, 8, 48, 16, 281, DateTimeKind.Unspecified).AddTicks(9041), 7 }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, new DateTime(2023, 8, 31, 9, 14, 31, 775, DateTimeKind.Unspecified).AddTicks(1126), 6 },
                    { 2, new DateTime(2022, 2, 2, 7, 59, 50, 154, DateTimeKind.Unspecified).AddTicks(6724), 8 },
                    { 3, new DateTime(2016, 7, 8, 9, 21, 40, 352, DateTimeKind.Unspecified).AddTicks(4672), 7 },
                    { 4, new DateTime(2022, 6, 2, 23, 37, 6, 24, DateTimeKind.Unspecified).AddTicks(2184), 5 }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
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
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, "Et consequatur id nisi et ipsum omnis ut.", 4, 4, 2 },
                    { 2, "Ex ratione velit consequatur earum optio doloribus sit similique.", 3, 1, 5 },
                    { 3, "Qui asperiores eos nemo ab quo ut iusto beatae eos.", 2, 4, 3 },
                    { 4, "Rerum voluptatum vel deleniti consectetur assumenda eaque exercitationem tenetur.", 2, 4, 5 },
                    { 5, "Quis quidem ut velit dignissimos maiores inventore consequatur voluptatibus suscipit.", 1, 3, 8 },
                    { 6, "Autem fuga officia eveniet neque perspiciatis maxime consequuntur libero soluta.", 2, 2, 7 }
========
                    { 1, "Eos atque possimus ipsum enim eius ipsam nostrum pariatur.", 3, 4, 5 },
                    { 2, "Quas occaecati qui quod dolor quia magnam doloremque.", 3, 4, 6 },
                    { 3, "Reprehenderit quod doloremque est et quia est natus nobis et.", 4, 2, 4 },
                    { 4, "Illo quia suscipit totam accusantium doloribus qui nam sed ullam.", 4, 4, 7 },
                    { 5, "Qui incidunt amet excepturi impedit mollitia repellendus dolores aliquid.", 3, 1, 8 },
                    { 6, "Incidunt neque natus deserunt quae totam minus quibusdam et accusantium.", 2, 3, 2 }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, "Id qui id non quaerat ab eum molestias quasi.", 4, 4, 8 },
                    { 2, "Sunt debitis iusto odio et modi doloribus consequatur.", 2, 4, 2 },
                    { 3, "Est consequatur est animi enim magnam illum alias nobis.", 2, 3, 4 },
                    { 4, "Necessitatibus sint eaque recusandae reprehenderit delectus quasi aut.", 4, 1, 1 },
                    { 5, "Culpa fugit qui laboriosam in nihil occaecati vitae eaque.", 2, 1, 2 },
                    { 6, "Aliquid et saepe nemo omnis non nulla assumenda corporis.", 3, 5, 4 }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, 2, 3, 3 },
                    { 2, 4, 3, 7 },
                    { 3, 4, 2, 6 },
                    { 4, 2, 3, 6 }
========
                    { 1, 1, 4, 1 },
                    { 2, 4, 2, 8 },
                    { 3, 1, 1, 4 },
                    { 4, 3, 4, 4 }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, 4, 4, 2 },
                    { 2, 3, 5, 3 },
                    { 3, 1, 2, 5 },
                    { 4, 1, 5, 7 }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
<<<<<<<< HEAD:DAL.WebMVC.Migrations/Migrations/20251114124303_remigrated.cs
                    { 1, 2, 1, 4 },
                    { 2, 3, 1, 2 },
                    { 3, 4, 1, 3 },
                    { 4, 4, 2, 5 },
                    { 5, 1, 2, 2 },
                    { 6, 4, 3, 1 },
                    { 7, 4, 3, 3 },
                    { 8, 1, 3, 1 },
                    { 9, 3, 4, 5 },
                    { 10, 1, 4, 1 }
========
                    { 1, 1, 1, 1 },
                    { 2, 3, 1, 1 },
                    { 3, 1, 1, 5 },
                    { 4, 1, 2, 5 },
                    { 5, 3, 3, 2 },
                    { 6, 2, 3, 2 },
                    { 7, 1, 4, 1 },
                    { 8, 2, 4, 5 },
                    { 9, 4, 4, 1 }
>>>>>>>> cd684c3 (seeded Orders to DBs):DAL.WebAPI.Migrations/Migrations/20251030170836_migrated_migration.cs
========
                    { 1, 2, 1, 2 },
                    { 2, 1, 2, 4 },
                    { 3, 4, 2, 4 },
                    { 4, 1, 3, 3 },
                    { 5, 1, 3, 1 },
                    { 6, 2, 3, 3 },
                    { 7, 4, 4, 3 },
                    { 8, 4, 4, 3 },
                    { 9, 4, 4, 5 }
>>>>>>>> 20ed764 (fix migration conflicts):DAL.WebAPI.Migrations/Migrations/20251111212257_remigrated.cs
                });

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
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
