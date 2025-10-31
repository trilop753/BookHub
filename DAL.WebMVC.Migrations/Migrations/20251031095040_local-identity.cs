using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class localidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalIdentityUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_LocalIdentityUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalIdentityUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Rafael", "Padberg" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Kavon", "Borer" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Samanta", "Graham" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Meta", "Breitenberg" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Ford", "Sawayn" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Earum voluptas magni est nulla illum ut occaecati. Necessitatibus explicabo vitae delectus expedita dolorem delectus. Qui non sint quidem accusantium perspiciatis. Magni libero unde consequatur magnam reprehenderit. Ut delectus sapiente voluptas eum praesentium iure.", "5066116065970", 7.32m, 4, "Architecto et est et ipsa autem." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 4, "Non sequi vel ut eos. Mollitia officiis et soluta deserunt maiores. Possimus molestias molestiae quam dolore est quo. Reprehenderit dicta itaque amet rerum dicta. Exercitationem aliquid similique accusamus corrupti optio. Labore maxime voluptas.", "9290610238158", 19.14m, 4, "Sit consectetur numquam asperiores." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { "Enim incidunt voluptates autem. Voluptas placeat sit sed quibusdam quis quisquam ea dolorem. Fugit et vel. Vero veniam nulla unde dolore.", "7950073956229", 12.65m, 1, "Nulla animi voluptate id." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 5, "Voluptatibus eaque consequatur voluptatibus est. Non perspiciatis corporis saepe suscipit reiciendis omnis. Est incidunt eos rem delectus ea sequi non. Et quo ipsa quis. Sunt mollitia fugiat molestiae optio dolorum. Et corrupti ab tenetur velit commodi eligendi modi.", "7465822066895", 7.05m, 3, "Laboriosam voluptas et est." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Qui commodi maiores adipisci iure soluta et labore maxime.", 4, 5, 8 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId", "UserId" },
                values: new object[] { "Ut quibusdam eaque libero omnis sunt quisquam omnis mollitia.", 4, 7 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Sunt consequatur atque laboriosam officia minima dignissimos fuga placeat.", 4, 7 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars" },
                values: new object[] { "Quia at facilis ut non maiores ex mollitia.", 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Corporis est aspernatur ut blanditiis amet distinctio et consequatur.", 3, 3, 6 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Iure explicabo repudiandae et corporis sint quo nemo sint et.", 3, 4, 4 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "UserId" },
                values: new object[] { 5, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 3, 7 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 18, 9, 52, 48, 798, DateTimeKind.Unspecified).AddTicks(5224), 3 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 9, 3, 11, 44, 10, 136, DateTimeKind.Unspecified).AddTicks(10), 8 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 8, 2, 16, 41, 31, 209, DateTimeKind.Unspecified).AddTicks(5379), 7 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2015, 4, 14, 22, 44, 58, 5, DateTimeKind.Unspecified).AddTicks(3963), 7 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 4, 2, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 4, 3, 1 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 5, 4, 3, 3 },
                    { 6, 2, 3, 2 },
                    { 7, 2, 4, 5 },
                    { 8, 2, 4, 5 },
                    { 9, 1, 4, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Fahey Group");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Schuster LLC");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Johnson - Murazik");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Franecki, Ankunding and Stamm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Ruby45@yahoo.com", "Karelle.Spinka40" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Erika6@hotmail.com", "Caterina_Schultz59" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Verlie.Haag@yahoo.com", "Declan.Wisoky" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Makayla78@yahoo.com", "Beaulah_Kutch" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Jamel12@yahoo.com", false, "Casimer.Carroll" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Pattie_Langosh70@hotmail.com", false, "Kiara.Ebert" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Linwood91@hotmail.com", "Montana.Roob" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Doris_Cummings51@hotmail.com", true, "Davion.Kuphal" });

            migrationBuilder.CreateIndex(
                name: "IX_LocalIdentityUsers_UserId",
                table: "LocalIdentityUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalIdentityUsers");

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "John", "Greenholt" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Arielle", "Dach" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Sigrid", "Hilpert" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Jaida", "McGlynn" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Billy", "Gleichner" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 5, "Sed rerum sint rerum nulla animi excepturi eum labore. Esse accusamus soluta harum. Esse ad et odio enim aut. Sit maiores repudiandae voluptate. Cum architecto totam rem debitis voluptatibus sunt quo. Rerum est laudantium fuga.", "1218922640276", 10.08m, 1, "Voluptates magnam et cum et et." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Beatae molestiae iure sed. Possimus et commodi sed deserunt. Consequatur hic autem modi animi maxime molestias delectus vitae minus.", "7391436449918", 6.00m, 1, "Eum laboriosam fuga nesciunt aperiam." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { "Quo voluptatum aut ipsam et commodi architecto fuga. Voluptatem accusamus voluptatum aut. Nesciunt at illo expedita quae sed nostrum enim voluptatem delectus.", "6748890487047", 5.50m, 2, "Nostrum et doloremque est." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 3, "Nihil aliquid quia nisi aut nemo. Nulla expedita rerum esse dolorem ipsa quis quia. Tempora quae blanditiis debitis. Modi assumenda cum ut quidem tempore qui. Aut enim aspernatur sapiente voluptas beatae magni. Earum ea fugiat veritatis non.", "0969173285723", 15.68m, 2, "Deserunt tempore suscipit expedita consequatur consequatur." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Sequi consectetur aliquid illum quisquam dolor ea ut quas in.", 2, 2, 6 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId", "UserId" },
                values: new object[] { "Dolorem qui quo sed minima repellendus rerum quas.", 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Fuga at provident vel placeat voluptas iusto dolores voluptas.", 5, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars" },
                values: new object[] { "Voluptatem inventore libero consequatur consequatur ut quis enim voluptates labore.", 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Iure voluptatum error aperiam iure et enim officia.", 1, 4, 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Sed sit repellat natus aliquam consequuntur minima laboriosam.", 4, 1, 3 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "UserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 4, 4, 5 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2017, 10, 17, 16, 58, 46, 742, DateTimeKind.Unspecified).AddTicks(1395), 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 5, 26, 20, 36, 13, 909, DateTimeKind.Unspecified).AddTicks(3833), 6 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 12, 26, 13, 33, 41, 766, DateTimeKind.Unspecified).AddTicks(3126), 6 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 3, 28, 7, 54, 36, 422, DateTimeKind.Unspecified).AddTicks(3462), 1 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 1, 3, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 2, 4, 5 });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mayert Inc");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Reichert LLC");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "VonRueden - Hilpert");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Brakus Inc");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Donald.Spencer@yahoo.com", "Lynn1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Judge4@gmail.com", "Ashley_Reichel" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Lauryn_Romaguera@yahoo.com", "Kaitlyn.Wehner" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Morris.Kassulke@yahoo.com", "Bertram.Harber45" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Helene_Hane12@hotmail.com", true, "Miguel7" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Dedrick.Torphy@gmail.com", true, "Earnestine42" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Eugenia_Hamill@yahoo.com", "Maxine.Hilpert82" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Ottilie_Pagac83@yahoo.com", false, "Nicolette_Fritsch" });
        }
    }
}
