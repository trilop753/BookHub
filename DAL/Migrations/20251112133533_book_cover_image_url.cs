using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class book_cover_image_url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Book",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Cooper", "Stokes" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Mabel", "Abshire" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Miles", "Koelpin" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Georgianna", "Schneider" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "June", "Nader" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "Description", "EditCount", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { null, "In illum aut iste architecto ipsum. Neque quidem est. Quis sunt harum labore quae odit et voluptatem iusto corrupti.", 10, "1068470320720", 16.82m, 4, "Molestiae vero dicta minus." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "Price", "Title" },
                values: new object[] { 4, null, "Nostrum quae tempora laboriosam rerum ipsa ea aliquam. Quia similique quo animi quis ab. Ipsum voluptatem enim id earum neque. Voluptas velit voluptatem. Iusto est accusantium et deleniti voluptas ipsam dicta.", 2, "2392916681861", 14.90m, "Fuga quis repudiandae praesentium." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 3, null, "Corrupti quidem voluptate eveniet aliquam expedita delectus. Itaque optio consequatur tenetur quia hic maxime qui ea. Quae reiciendis architecto fugit ut et velit quia. Sed explicabo atque. Modi a qui et in autem quam nihil nobis animi.", 2, "9265726409150", 3, 18.96m, 1, "Molestiae omnis animi quibusdam veniam animi." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "Description", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { null, "Ipsum est voluptatem est et. Vero ipsum reprehenderit ex inventore corrupti nostrum mollitia in deleniti. Ipsum perferendis magni.", "5343042455397", 2, 15.17m, 2, "Rerum dolorem perspiciatis illum ad quasi." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Odio a repellendus est distinctio eum laudantium ipsa exercitationem maiores.", 2, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Voluptatem odio nihil dolorem maiores magnam omnis quia commodi.");

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "UserId" },
                values: new object[] { "Ut esse velit dolores ut non maxime suscipit omnis dolor.", 4, 5 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Eum et in consectetur fugit ea praesentium debitis.", 5, 6 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Eligendi quidem eum inventore ratione ratione debitis aut.", 3, 4, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "UserId" },
                values: new object[] { "Qui dolor quasi mollitia ea possimus error nesciunt numquam.", 1, 2 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 1, 6 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 1, 6 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 5, 10, 7, 7, 54, 773, DateTimeKind.Unspecified).AddTicks(1214), 8 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2022, 5, 26, 15, 56, 29, 908, DateTimeKind.Unspecified).AddTicks(672), 3 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2021, 3, 19, 21, 28, 53, 171, DateTimeKind.Unspecified).AddTicks(2950), 6 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 9, 25, 9, 57, 29, 631, DateTimeKind.Unspecified).AddTicks(9082), 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 2, 1, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "BookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "BookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Doyle - Cruickshank");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Romaguera - Weissnat");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ankunding Group");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Kshlerin, Brakus and Heidenreich");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Tomas54@yahoo.com", "Aaron_Schoen68" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Lucile.VonRueden@yahoo.com", "Isaac_Block61" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Olaf_Tillman0@hotmail.com", true, "Rosendo_Schultz29" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Vance_Gibson27@yahoo.com", "Jaida_Kessler21" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Skyla.Kirlin84@hotmail.com", "Adelle.Okuneva" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Alfredo.Maggio@yahoo.com", "Leopoldo63" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Jerome5@gmail.com", "Adolfo14" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Easton75@hotmail.com", "Maverick_Konopelski80" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Book");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Reba", "Weber" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Mina", "Brown" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Raegan", "Cruickshank" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Destini", "Cummings" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Bernhard", "Ankunding" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EditCount", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { "Exercitationem fuga voluptates esse consequatur ipsum qui dignissimos et. Et aut consequatur. Consequatur assumenda ex animi.", 4, "1614468034270", 11.38m, 3, "Culpa velit sapiente quisquam." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "EditCount", "ISBN", "Price", "Title" },
                values: new object[] { 1, "Nisi nobis ut. Voluptate magnam tempore. Repellendus aliquid quod itaque unde adipisci. Officiis repudiandae dolore qui voluptate ad impedit repudiandae atque.", 7, "0795729932984", 19.15m, "Cumque impedit blanditiis error." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Veritatis voluptatem magni incidunt quod cumque voluptatem velit distinctio aliquam. Culpa libero sed molestias voluptatem blanditiis ut esse. Perspiciatis earum eos. Nesciunt culpa ut omnis impedit commodi ut. Rerum accusamus ipsum dolorum nisi quibusdam voluptatem hic occaecati ducimus. Porro aspernatur voluptatibus tenetur.", 10, "7887396245146", 4, 14.28m, 3, "Laudantium dolor magnam rerum." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { "Distinctio possimus rerum repellat. Velit consectetur perspiciatis. Dolores adipisci et et fugit quod voluptatibus.", "4295003193637", 1, 14.29m, 1, "Consequatur dolorum eos possimus." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Dolor aliquid id quidem quas aut dolor cumque aut.", 1, 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Fugit illo sunt debitis quasi consequatur et delectus.");

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "UserId" },
                values: new object[] { "Dolores nemo reprehenderit quasi assumenda culpa natus necessitatibus.", 3, 6 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Sunt rerum dicta ratione magni provident qui laudantium asperiores.", 4, 5 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Voluptatem assumenda ut est voluptatem ea qui eius.", 4, 3, 6 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "UserId" },
                values: new object[] { "Architecto sed omnis quo sint a ex cupiditate.", 4, 7 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 4, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 5, 8 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2022, 7, 25, 7, 50, 52, 232, DateTimeKind.Unspecified).AddTicks(882), 6 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 1, 10, 9, 55, 59, 462, DateTimeKind.Unspecified).AddTicks(2736), 7 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2020, 1, 25, 3, 23, 45, 60, DateTimeKind.Unspecified).AddTicks(7410), 3 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2022, 9, 26, 22, 54, 20, 65, DateTimeKind.Unspecified).AddTicks(8319), 7 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "BookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "BookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[] { 9, 1, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Gerhold, Ruecker and Huel");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Swaniawski - Collins");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Willms, Windler and Lehner");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Hegmann LLC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Fanny.Witting@yahoo.com", "Hilma.Pfeffer38" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Justice.Kunde84@hotmail.com", "Tevin_Hackett" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Lavada85@yahoo.com", false, "Emory90" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Murphy85@gmail.com", "Elisabeth.Powlowski61" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Raleigh56@gmail.com", "Alfonso45" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Brant47@hotmail.com", "Pauline_Roob" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Lera.Bode@yahoo.com", "Jacinto39" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Mitchell44@hotmail.com", "Hayley.Walter" });
        }
    }
}
