using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Josh", "Reynolds" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Krystina", "Thiel" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Bethel", "Dietrich" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Jaeden", "Balistreri" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Ethan", "Hilpert" });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Alias ducimus voluptas qui soluta qui magnam consequatur et.", 4, 2, 7 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Stars" },
                values: new object[] { "Sequi autem corporis facere sunt qui ut quos.", 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Ea in repudiandae consequatur recusandae quo quasi enim laborum.", 4, 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Amet aut et magnam et necessitatibus molestias aspernatur quibusdam.", 4, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Consequatur error consequatur qui ratione impedit molestiae quia molestias.", 2, 5, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Nobis quaerat aut autem odio saepe aut magnam.", 4, 5, 8 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Sed nostrum facere fugit repellat fugit. Libero dolorum et rerum alias velit minus nam tempore. Error vitae voluptatem. Aliquid sed non omnis aut rerum harum nemo explicabo. Ea sed ut excepturi doloribus libero rerum.", "5698671925941", 5.42m, 2, "Pariatur aut dolor rerum." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 3, "Ut modi libero. Quam quam consequatur. Dolores et aut provident. Minima maxime ipsa culpa architecto et deleniti saepe. Accusamus et sit.", "5573080934343", 6.47m, 2, "Rem ducimus sed nisi." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 3, "Ab ut provident sed. Minus dolorum laboriosam nulla et. Quasi aperiam magnam qui quia. Minima et saepe. Repudiandae doloremque incidunt in ipsum et. Eos nesciunt qui fugit molestiae ad placeat sit.", "1164740686814", 16.69m, 4, "Voluptatem dolore soluta saepe fuga eos." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 1, "Cum aspernatur iusto beatae odit. Et molestiae fugiat eum aut harum molestias sit ducimus et. Ipsum at omnis. Quasi velit quo maxime quia ad a.", "4442655472454", 18.17m, 4, "Similique voluptas beatae suscipit unde." });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 2, 7 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 2, 8 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 4, 2, 4 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 25, 16, 58, 54, 862, DateTimeKind.Unspecified).AddTicks(1508), 6 },
                    { 2, new DateTime(2022, 9, 4, 18, 43, 32, 510, DateTimeKind.Unspecified).AddTicks(7550), 5 },
                    { 3, new DateTime(2023, 6, 3, 17, 32, 13, 463, DateTimeKind.Unspecified).AddTicks(927), 1 },
                    { 4, new DateTime(2015, 7, 21, 6, 32, 27, 858, DateTimeKind.Unspecified).AddTicks(6621), 5 }
                });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Hoeger, Champlin and Conn");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Stoltenberg Group");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "VonRueden Group");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Homenick Group");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Zula_Nienow@gmail.com", "Dustin_Glover" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Lilly46@yahoo.com", "Malvina.Stehr" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Ross.Bashirian@hotmail.com", "Tabitha.Cummerata87" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Keyshawn.Goyette@yahoo.com", "Liam.Wilderman93" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Lolita.Pouros@yahoo.com", "Cleora_Wintheiser" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Damien7@yahoo.com", "Jayne_Bauch" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Erich.OConner@gmail.com", "Dewayne_Fay97" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Franco96@yahoo.com", "Janice81" });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, 1, 3 },
                    { 2, 3, 1, 4 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 2, 4 },
                    { 5, 2, 3, 4 },
                    { 6, 1, 3, 3 },
                    { 7, 4, 4, 4 },
                    { 8, 4, 4, 3 },
                    { 9, 3, 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Leonard", "Koelpin" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Erich", "Dibbert" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Eleanora", "Altenwerth" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Yasmin", "Rutherford" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Layne", "Ziemann" });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Similique ut eveniet dolorem est exercitationem autem dolorum.", 3, 3, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Stars" },
                values: new object[] { "Perspiciatis id repellendus omnis atque nobis non quia.", 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Quia mollitia nobis non sed laborum sed repellat sunt aut.", 1, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Fuga eum qui temporibus quis consequatur velit architecto.", 5, 8 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Minima aperiam modi odit aperiam ratione ducimus quas repudiandae necessitatibus.", 4, 2, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Vel vitae molestiae quis sunt qui et qui.", 2, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 5, "Ea recusandae esse quod distinctio. Fugit nobis ex est earum quam quidem. Aliquam tempore magnam aut corporis.", "3331547405223", 15.73m, 4, "Non quos minima placeat." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 4, "Velit iusto quam aspernatur animi nisi exercitationem accusantium. Numquam blanditiis adipisci quos recusandae architecto iusto et odit deserunt. Cumque ipsam ut eaque velit. Suscipit molestiae est excepturi ipsam et deleniti voluptatem.", "0957600004610", 15.78m, 3, "Atque ipsum consequatur ut." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 1, "Suscipit est explicabo et sint. Et earum blanditiis. Molestias et rerum. Deleniti repellat ratione in excepturi quibusdam aut deserunt. Et nulla mollitia rem numquam eius pariatur. Necessitatibus maxime eligendi nihil dolore fugiat non voluptatibus minima ab.", "2363862910251", 15.04m, 2, "Hic similique eaque repellendus." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 4, "Eos vero magnam eaque maiores ullam qui rerum. Culpa ut odio magni. Quisquam velit exercitationem est aut cum ut quam.", "1486397463823", 18.69m, 2, "Rerum sunt labore nisi aliquam." });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 4, 1, 6 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 5, 5 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bartoletti, Weber and Stoltenberg");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Larson, Metz and Herzog");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hirthe Inc");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Crooks LLC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Erika.Lesch70@yahoo.com", "Roslyn.Quitzon76" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Kennith.Abbott27@gmail.com", "Pietro.Stehr" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Cheyanne.Beier64@yahoo.com", "Anna70" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Santos87@hotmail.com", "Sonia.Gerlach62" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Mekhi.Sporer4@yahoo.com", "May_Rutherford" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Ayana64@hotmail.com", "General.Fritsch" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Ryder50@hotmail.com", "Ilene55" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Devante_Larkin@hotmail.com", "Shaun.Nitzsche" });
        }
    }
}
