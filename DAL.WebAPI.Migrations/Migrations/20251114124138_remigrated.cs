using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
    public partial class remigrated : Migration
========
    public partial class migrated_migration : Migration
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
========
    public partial class mvc_init : Migration
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    CoverImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    EditCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LastEditedById = table.Column<int>(type: "INTEGER", nullable: true)
========
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs
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
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
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
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenresId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
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
                name: "OrderItem",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
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
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    { 1, "Jaeden", "Spencer" },
                    { 2, "Heath", "Hagenes" },
                    { 3, "Pietro", "Pollich" },
                    { 4, "Angie", "Gusikowski" },
                    { 5, "Rosina", "Rohan" }
========
                    { 1, "Brenda", "Aufderhar" },
                    { 2, "Terrell", "Braun" },
                    { 3, "Wilson", "Kassulke" },
                    { 4, "Lavinia", "Corwin" },
                    { 5, "Toby", "O'Keefe" }
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
                });
========
                    { 1, "Loren", "Baumbach" },
                    { 2, "Green", "Wisozk" },
                    { 3, "John", "Bergnaum" },
                    { 4, "Jalen", "Dietrich" },
                    { 5, "Derek", "Torphy" },
                }
            );
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs

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
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    { 1, "Lowe and Sons" },
                    { 2, "Prosacco LLC" },
                    { 3, "Connelly and Sons" },
                    { 4, "Gutkowski, Nitzsche and Metz" }
========
                    { 1, "Hermann, Jacobs and Hahn" },
                    { 2, "Hills - Murazik" },
                    { 3, "Runolfsson, Lueilwitz and Hilll" },
                    { 4, "Moen - Beatty" }
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
                });
========
                    { 1, "Kerluke - Lang" },
                    { 2, "Dare Group" },
                    { 3, "Bartell Group" },
                    { 4, "Klocko, Kerluke and Williamson" },
                }
            );
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBanned", "Username" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    { 1, "Piper0@yahoo.com", false, "Deborah_Connelly78" },
                    { 2, "Andres25@gmail.com", false, "Ayana78" },
                    { 3, "Elroy.Littel46@yahoo.com", true, "Bernita36" },
                    { 4, "Loyal68@yahoo.com", false, "Earlene_Stanton7" },
                    { 5, "Wiley_Lang5@yahoo.com", false, "Sammie_Gerlach25" },
                    { 6, "Joaquin20@hotmail.com", false, "Karelle28" },
                    { 7, "Brisa_OHara89@hotmail.com", false, "Hugh_Gutkowski96" },
                    { 8, "Irma.McCullough@gmail.com", false, "Ebony.Goldner25" }
========
                    { 1, "Jakob.Reinger@hotmail.com", false, "Glenna60" },
                    { 2, "Krista.Ritchie20@hotmail.com", false, "Mohamed.Ebert5" },
                    { 3, "Bradley77@gmail.com", false, "Pablo.Maggio" },
                    { 4, "Tavares_Lubowitz@yahoo.com", false, "Fausto.Littel67" },
                    { 5, "Brendan_Larkin86@hotmail.com", false, "Simeon_Kilback" },
                    { 6, "Julianne.OHara85@hotmail.com", false, "Raheem_Collins" },
                    { 7, "Chanelle89@gmail.com", false, "Evalyn_Feeney25" },
                    { 8, "Isom.Abernathy@hotmail.com", false, "Lora.Kovacek" }
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    { 1, 3, null, "Dolore repellat nihil est vitae. Rerum et omnis doloribus natus voluptatem ut nobis sed hic. Voluptates aut consequatur velit.", 9, "0252841398703", 5, 11.41m, 4, "Est vel ea expedita est deleniti." },
                    { 2, 5, null, "Accusamus ipsam quas mollitia harum voluptas dolor nisi. Et necessitatibus qui labore. Quam corporis neque eaque ipsam vel sint debitis ut.", 5, "1798988734374", 3, 7.34m, 4, "Ad quia aliquid deleniti labore." },
                    { 3, 3, null, "Sed id enim eos fuga aut qui voluptas quia iure. Qui excepturi ea nostrum perspiciatis qui. Et qui quas cupiditate est architecto. In veniam et assumenda voluptas consequatur eos quo quia.", 2, "2537844064977", 1, 19.76m, 4, "Sed accusamus odit ut omnis." },
                    { 4, 5, null, "Delectus qui sint cumque provident veritatis. Eius possimus pariatur non quas illo vitae id est culpa. At non voluptas. Et inventore doloremque qui et officia id. Perspiciatis qui eos rerum sit. Aut eos sapiente et assumenda voluptatum id aut voluptatem in.", 1, "8339265128122", 3, 12.32m, 2, "Et perspiciatis odit iste." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2016, 1, 30, 1, 9, 12, 910, DateTimeKind.Unspecified).AddTicks(1419), 2 },
                    { 2, new DateTime(2022, 8, 1, 21, 49, 14, 184, DateTimeKind.Unspecified).AddTicks(6406), 8 },
                    { 3, new DateTime(2018, 11, 13, 4, 15, 35, 945, DateTimeKind.Unspecified).AddTicks(6405), 5 },
                    { 4, new DateTime(2017, 8, 1, 21, 9, 39, 883, DateTimeKind.Unspecified).AddTicks(7815), 1 }
========
                    { 1, 1, "Reiciendis iste tenetur rerum fuga. Repudiandae animi molestiae reiciendis non ut aspernatur maiores. Similique et enim omnis dicta minus quo et veniam. Quos aliquid deleniti rem eum autem alias ab molestiae non. Explicabo ut id voluptate non iure ea velit deserunt. Voluptatum non cumque consectetur consequatur ut fugiat illo deleniti.", "0868155859139", 13.18m, 2, "Corporis blanditiis doloremque sequi distinctio dolor." },
                    { 2, 3, "Blanditiis sint consectetur est. Laboriosam minus maiores cum omnis commodi illo porro cumque voluptatibus. Voluptas sit cupiditate laudantium fugit perspiciatis voluptas hic et ut. Tempore saepe itaque placeat quia ullam vel nemo nostrum.", "0596656735378", 8.19m, 1, "Optio tempore est non quibusdam." },
                    { 3, 5, "Rerum quo ea velit. Perferendis sed non vel quam libero sunt. Nam et omnis quo sint ea. Qui architecto est.", "9801349351478", 14.90m, 1, "Omnis excepturi molestias at." },
                    { 4, 5, "Autem assumenda est ducimus voluptates veritatis voluptatem suscipit laudantium eaque. Debitis dolor distinctio debitis perferendis accusamus maxime quidem enim explicabo. Quasi quis ipsam est harum.", "2389728247217", 6.77m, 4, "Repellat beatae ullam ipsum quo." }
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
                });
========
                    { 1, "Clifton.Glover25@hotmail.com", false, "Moises54" },
                    { 2, "Susanna_Stanton92@yahoo.com", false, "Ottis.Olson99" },
                    { 3, "Otis69@yahoo.com", false, "Velva.Wiza0" },
                    { 4, "Madaline_Glover89@yahoo.com", false, "Penelope_Harvey44" },
                    { 5, "Skye47@gmail.com", false, "Cicero_Kuvalis" },
                    { 6, "Maurine.Kassulke47@yahoo.com", false, "Ethan.Schinner" },
                    { 7, "Rosina_Fadel@gmail.com", false, "Mallie.Hamill" },
                    { 8, "Pablo.Stoltenberg@gmail.com", false, "Shaina.Monahan" },
                }
            );

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[]
                {
                    "Id",
                    "AuthorId",
                    "Description",
                    "ISBN",
                    "Price",
                    "PublisherId",
                    "Title",
                },
                values: new object[,]
                {
                    {
                        1,
                        1,
                        "Occaecati voluptas omnis neque aut. Repellendus sint quo sunt qui. Et error autem corrupti sed. Voluptate vitae omnis voluptas praesentium ratione porro et qui.",
                        "6250995845108",
                        18.21m,
                        4,
                        "Dolorem sed explicabo voluptatem.",
                    },
                    {
                        2,
                        3,
                        "Et dolore aperiam omnis sit est. Consequatur voluptas sunt suscipit dicta neque ut. Pariatur non ut animi.",
                        "6971673232408",
                        16.55m,
                        2,
                        "Iste rerum molestiae magnam deserunt.",
                    },
                    {
                        3,
                        5,
                        "Aut quia atque autem. Omnis pariatur est facere maxime suscipit et cum. Non dolores quo rerum culpa ducimus labore corrupti et.",
                        "4107919391413",
                        8.03m,
                        3,
                        "Esse earum consectetur sed.",
                    },
                    {
                        4,
                        3,
                        "A voluptatem voluptas beatae. Ut molestiae iste ex voluptatem et amet architecto inventore nesciunt. Culpa cupiditate consequuntur. Laborum sit est sequi.",
                        "1969173267292",
                        5.63m,
                        2,
                        "At quis eum quasi omnis iste.",
                    },
                }
            );
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 5 },
                }
            );

            migrationBuilder.InsertData(
                table: "BookReview",
                columns: new[] { "Id", "Body", "BookId", "Stars", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    { 1, "Odio alias pariatur dolore est est voluptatum rerum.", 4, 3, 8 },
                    { 2, "Pariatur voluptatem dolorem iusto id incidunt voluptas est distinctio repellendus.", 3, 4, 5 },
                    { 3, "Debitis quae ut qui et pariatur fuga non velit.", 2, 3, 2 },
                    { 4, "Magnam nemo repellendus occaecati ut perspiciatis laudantium possimus qui.", 1, 4, 1 },
                    { 5, "Consequatur blanditiis accusantium vitae quis nihil enim tempore totam.", 3, 4, 7 },
                    { 6, "Eum voluptatum mollitia quibusdam incidunt recusandae voluptatem sunt rerum itaque.", 3, 5, 7 }
========
                    { 1, "Voluptatem voluptate inventore repellendus id nobis et repudiandae ut.", 3, 4, 4 },
                    { 2, "Numquam eligendi accusamus autem est et omnis aut neque laboriosam.", 3, 1, 2 },
                    { 3, "Et consequuntur similique sunt ad rerum voluptas mollitia.", 2, 5, 7 },
                    { 4, "Eos totam et sit et distinctio iste tenetur.", 1, 1, 7 },
                    { 5, "Quisquam occaecati quia temporibus earum voluptatem iusto vel ea repellat.", 4, 1, 3 },
                    { 6, "Atque dolore saepe autem ut perferendis modi dignissimos consequatur.", 3, 3, 6 }
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
                });
========
                    { 1, "Nemo minus ut dicta tenetur voluptatem quos reiciendis sit.", 3, 4, 4 },
                    { 2, "Quia esse est consequatur eius eveniet sint sunt vel.", 3, 2, 7 },
                    { 3, "Ea asperiores excepturi aut voluptatum fuga id iste quidem.", 3, 5, 1 },
                    {
                        4,
                        "Unde amet occaecati non natus qui inventore incidunt deserunt.",
                        1,
                        1,
                        6,
                    },
                    {
                        5,
                        "Voluptate sequi quo quis repudiandae voluptatem corrupti eos sunt.",
                        3,
                        2,
                        5,
                    },
                    { 6, "Ipsum quia non quas et reprehenderit atque sunt corporis.", 4, 4, 5 },
                }
            );
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "BookId", "Quantity", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
<<<<<<<< HEAD:DAL.WebAPI.Migrations/Migrations/20251114124138_remigrated.cs
                    { 1, 1, 4, 2 },
                    { 2, 3, 2, 4 },
                    { 3, 2, 2, 2 },
                    { 4, 4, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 3, 1, 3 },
                    { 2, 1, 1, 5 },
                    { 3, 4, 1, 4 },
                    { 4, 2, 2, 3 },
                    { 5, 4, 2, 5 },
                    { 6, 3, 2, 3 },
                    { 7, 4, 3, 2 },
                    { 8, 2, 3, 2 },
                    { 9, 3, 3, 3 },
                    { 10, 3, 4, 5 }
========
                    { 1, 3, 4, 3 },
                    { 2, 1, 2, 5 },
                    { 3, 1, 4, 8 },
                    { 4, 4, 4, 2 }
>>>>>>>> 3a29d09 (separate API and MVC migrations):DAL.WebAPI.Migrations/Migrations/20251030121702_migrated_migration.cs
                });
========
                    { 1, 4, 5, 7 },
                    { 2, 4, 3, 8 },
                    { 3, 3, 4, 4 },
                    { 4, 3, 2, 4 },
                }
            );
>>>>>>>> 3f000ad (separate API and MVC migrations):DAL.WebMVC.Migrations/Migrations/20251030124614_mvc_init.cs

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId"
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

            migrationBuilder.CreateIndex(name: "IX_Order_UserId", table: "Order", column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_BookId",
                table: "OrderItem",
                column: "BookId"
            );

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BookGenre");

            migrationBuilder.DropTable(name: "BookReview");

            migrationBuilder.DropTable(name: "CartItem");

            migrationBuilder.DropTable(name: "OrderItem");

            migrationBuilder.DropTable(name: "WishlistItem");

            migrationBuilder.DropTable(name: "Genre");

            migrationBuilder.DropTable(name: "Order");

            migrationBuilder.DropTable(name: "Book");

            migrationBuilder.DropTable(name: "User");

            migrationBuilder.DropTable(name: "Author");

            migrationBuilder.DropTable(name: "Publisher");
        }
    }
}
