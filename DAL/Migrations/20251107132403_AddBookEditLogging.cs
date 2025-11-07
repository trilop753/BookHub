using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBookEditLogging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditCount",
                table: "Book",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastEditedById",
                table: "Book",
                type: "INTEGER",
                nullable: true);

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
                columns: new[] { "AuthorId", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "Title" },
                values: new object[] { 4, "Exercitationem fuga voluptates esse consequatur ipsum qui dignissimos et. Et aut consequatur. Consequatur assumenda ex animi.", 4, "1614468034270", 4, 11.38m, "Culpa velit sapiente quisquam." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 1, "Nisi nobis ut. Voluptate magnam tempore. Repellendus aliquid quod itaque unde adipisci. Officiis repudiandae dolore qui voluptate ad impedit repudiandae atque.", 7, "0795729932984", 3, 19.15m, 2, "Cumque impedit blanditiis error." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { "Veritatis voluptatem magni incidunt quod cumque voluptatem velit distinctio aliquam. Culpa libero sed molestias voluptatem blanditiis ut esse. Perspiciatis earum eos. Nesciunt culpa ut omnis impedit commodi ut. Rerum accusamus ipsum dolorum nisi quibusdam voluptatem hic occaecati ducimus. Porro aspernatur voluptatibus tenetur.", 10, "7887396245146", 4, 14.28m, 3, "Laudantium dolor magnam rerum." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Distinctio possimus rerum repellat. Velit consectetur perspiciatis. Dolores adipisci et et fugit quod voluptatibus.", 8, "4295003193637", 1, 14.29m, 1, "Consequatur dolorum eos possimus." });

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
                columns: new[] { "Body", "BookId" },
                values: new object[] { "Fugit illo sunt debitis quasi consequatur et delectus.", 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "Stars" },
                values: new object[] { "Dolores nemo reprehenderit quasi assumenda culpa natus necessitatibus.", 3, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                column: "Body",
                value: "Sunt rerum dicta ratione magni provident qui laudantium asperiores.");

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
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Architecto sed omnis quo sint a ex cupiditate.", 4, 3, 7 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 1, 5 });

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
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 1, 1 });

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
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 4, 2, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookId", "OrderId" },
                values: new object[] { 1, 3 });

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
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "BookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 4 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Book_LastEditedById",
                table: "Book",
                column: "LastEditedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_User_LastEditedById",
                table: "Book",
                column: "LastEditedById",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_User_LastEditedById",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_LastEditedById",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "EditCount",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LastEditedById",
                table: "Book");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Jermey", "Lehner" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Pascale", "Spencer" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Vivianne", "O'Reilly" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Arvid", "Wolff" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Hermina", "Prosacco" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[] { 5, "Omnis modi magnam dolores voluptas. Et officiis sed voluptas odit facere quam. Odit doloremque dignissimos et. Omnis et est. Deserunt corporis molestiae quasi consequuntur. Dignissimos ab aspernatur asperiores est.", "6990281470026", 7.71m, "Qui provident saepe quam cum perferendis." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Assumenda et quia et et iste. A ea ut vel quod maxime rem dolorem qui. Excepturi et at. Consequatur et autem repudiandae.", "3695979644170", 19.06m, 4, "Ut cupiditate a consectetur repellat eos." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { "Vero quidem et. Ad natus qui. Autem qui rerum eos et. Eos sunt quo odit sapiente expedita expedita cumque et. Odit quo tenetur eveniet dolorum. Officiis inventore dolore harum quo rerum corrupti.", "1380438581388", 13.31m, 2, "Mollitia consequatur maiores velit minus cum." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 5, "Aut quasi officiis vel beatae. Ea doloremque itaque voluptatibus officiis nisi omnis. Architecto exercitationem molestiae temporibus. Error quibusdam et quod est non rerum quae et tempora. Dicta dolorum dolorum magni possimus dolore quam dolor et. Veritatis ducimus nemo id autem.", "2239462964584", 13.80m, 3, "Et et et accusantium." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Sed odio consequatur ratione ut velit est totam eum.", 4, 8 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId" },
                values: new object[] { "Laboriosam rerum iure distinctio ut aliquid reprehenderit suscipit.", 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "Stars" },
                values: new object[] { "Nulla sit modi sit quos quo nisi dolore.", 1, 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                column: "Body",
                value: "Nihil quis dolor magni est qui eos provident ipsam eum.");

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Qui nihil occaecati sed sit illum incidunt dicta totam dolor.", 1, 1, 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Et est aut fugit ea veniam eum modi possimus.", 3, 2, 8 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 3, 4 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 2, 3 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2017, 1, 14, 1, 49, 36, 113, DateTimeKind.Unspecified).AddTicks(3304), 5 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2017, 6, 22, 12, 55, 59, 832, DateTimeKind.Unspecified).AddTicks(5418), 6 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 8, 12, 22, 8, 47, 586, DateTimeKind.Unspecified).AddTicks(287), 4 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 6, 7, 9, 11, 10, 671, DateTimeKind.Unspecified).AddTicks(1508), 8 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 4, 1, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 3, 1, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookId", "OrderId" },
                values: new object[] { 3, 2 });

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
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "BookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Schroeder, Stoltenberg and Shanahan");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Torp - Tromp");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Jacobi, Tillman and Jones");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Hudson LLC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Estrella57@gmail.com", "Terrill57" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Dennis.Kuhn49@yahoo.com", "Myrna_OKon" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Filomena.Morar@hotmail.com", true, "Emanuel72" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Godfrey.Jaskolski@gmail.com", "Neva.Treutel97" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Alford.Fisher@yahoo.com", "Madaline_Osinski" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Santiago.Kemmer80@yahoo.com", "Lessie.Turcotte24" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Manuela_Fay@yahoo.com", "Rachelle88" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Joany_Corwin1@gmail.com", "Aaron.Streich24" });
        }
    }
}
