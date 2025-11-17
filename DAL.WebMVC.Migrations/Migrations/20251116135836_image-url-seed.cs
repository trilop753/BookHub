using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.WebMVC.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class imageurlseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "Emmy", "Ward" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Malachi", "Kiehn" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Roscoe", "Stracke" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Ebba", "Beier" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Ilene", "Franecki" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 4, "https://www.epubbooks.com/images/covers/th/the-king-in-yellow-8d4d06.jpg", "Esse autem a. Ex dignissimos cum animi fugiat quaerat non optio illum est. Delectus corrupti odio. Rerum earum eveniet. Id assumenda ut laudantium qui repellat beatae natus beatae.", 2, "1092875948586", 5, 12.34m, 2, "Sunt deserunt similique id est." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 3, "https://images2.patro.cz/550x600/000/000/081/000000081441_0.jpg", "Excepturi dolores consequatur velit natus odio atque modi. Laudantium architecto incidunt et sed. Hic sed quisquam dicta odit iusto quia accusamus ducimus.", "0297355312005", 2, 18.68m, 2, "Saepe inventore voluptas magnam." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { "https://www.slovart.cz/buxus/images/image_25007_19_v1.jpeg", "Modi sit quas earum deleniti beatae tenetur aliquam officiis sint. Officia velit optio est accusamus laudantium velit. Dicta ducimus omnis et nam amet enim. Quia culpa rerum ipsum in itaque vero odio illo. Fuga quia ut voluptas ipsum dolorem.", 10, "0131628341227", 1, 15.87m, 4, "Vitae voluptatibus porro nihil veritatis explicabo." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "Title" },
                values: new object[] { 2, "https://cdn.knihcentrum.cz/98535435_metro-2033-4.jpg", "Reiciendis cumque nihil non ut enim est. Nobis cumque aut asperiores qui iste molestiae enim consequatur. Eaque adipisci delectus qui illum accusamus corporis atque dolorem. Facilis aut dignissimos.", 5, "0789491984470", 2, 19.94m, "Aut numquam quia est cupiditate." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Non voluptas quaerat tempora culpa illum quas iure facilis harum.", 2, 1, 7 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Sunt ut quia omnis iusto et mollitia sint illum.", 1, 4, 5 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Eum quia eos excepturi et expedita consequatur quos deserunt.", 2, 5, 7 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Dolor numquam soluta reiciendis ex id error temporibus blanditiis.", 1, 5, 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Rerum enim tempore nulla ratione sint praesentium aperiam.", 2, 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Temporibus non consequatur ad nesciunt vel aliquam dolores dolorum.", 5, 7 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 3, 4 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "UserId" },
                values: new object[] { 5, 6 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 5, 2 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 15, 3, 25, 28, 668, DateTimeKind.Unspecified).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 1, 23, 21, 31, 30, 974, DateTimeKind.Unspecified).AddTicks(7040), 7 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2020, 7, 23, 9, 4, 49, 680, DateTimeKind.Unspecified).AddTicks(8765), 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 6, 13, 18, 46, 38, 332, DateTimeKind.Unspecified).AddTicks(8925), 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "OrderId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OrderId", "Quantity" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 1, 4, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 1, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Murazik, Bogisich and Klein");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bartell, Skiles and Lockman");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hintz - Casper");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Kling - Stark");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Wilfred44@yahoo.com", true, "Roscoe_Larson83" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Ewald.Schuster@gmail.com", "Isabelle_Ebert" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Elliott_Brekke0@yahoo.com", "Camilla63" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Ricardo_Crist66@gmail.com", "Roderick.Hoeger32" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Dax.Osinski@gmail.com", "Marcella_Kertzmann12" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Leann9@hotmail.com", "Carlee38" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Harmon28@gmail.com", true, "Efren89" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Luther76@yahoo.com", "Georgianna99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Cindy", "Buckridge" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Damion", "Grady" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Jade", "Parker" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Sister", "Mayer" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Guadalupe", "Leuschke" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 5, null, "Est voluptatum perspiciatis omnis sint. Repellendus omnis iure voluptatem occaecati fugiat animi. Et itaque temporibus.", 8, "4488423874075", 4, 19.25m, 4, "Omnis aut quisquam dolorum minus." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { 2, null, "Debitis dignissimos consequuntur dolorum quis praesentium est inventore. Voluptas sed accusamus. Id id molestiae et pariatur minus inventore sapiente quas dolor. Enim modi earum corporis accusantium sit. Non quo ipsa quos nam excepturi. Delectus corrupti porro nesciunt vel veritatis.", "5401414603521", 4, 16.11m, 1, "Harum itaque ad enim numquam." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "PublisherId", "Title" },
                values: new object[] { null, "Facilis ad aspernatur dicta hic est. Est magni id tenetur dolorum quod sit explicabo. Recusandae doloremque amet nam velit suscipit. Atque et quibusdam doloribus similique itaque officiis. Labore neque dignissimos impedit facilis aut voluptatem aut voluptas. Maiores qui architecto quis.", 4, "6605619285257", 4, 14.43m, 3, "Quia ut expedita reiciendis rerum distinctio." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CoverImageUrl", "Description", "EditCount", "ISBN", "LastEditedById", "Price", "Title" },
                values: new object[] { 4, null, "Repellendus officia dolores reiciendis voluptatem. Consequatur cupiditate adipisci eligendi delectus deserunt sunt vero id. Animi in nihil magni modi. Ut ut iste. Qui occaecati fuga velit consequatur rem nam et.", 8, "5849763713254", 5, 16.14m, "Assumenda consequatur libero dolore suscipit." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Minus qui ipsa ex alias nesciunt id aspernatur perferendis.", 4, 5, 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Molestiae minus optio deserunt modi aut atque amet.", 4, 1, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Autem fugit animi aut sed repellendus quo dolore libero.", 4, 4, 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Quos molestias iure autem porro magni at culpa.", 2, 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Facilis adipisci reprehenderit magnam cupiditate expedita cum nemo labore nobis.", 3, 3, 8 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Sint eius fugit eaque velit ex nobis quo.", 4, 2 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 1, 8 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "UserId" },
                values: new object[] { 2, 2 });

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
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 31, 17, 18, 40, 232, DateTimeKind.Unspecified).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 12, 16, 10, 2, 40, 629, DateTimeKind.Unspecified).AddTicks(2375), 5 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2021, 2, 24, 16, 39, 57, 681, DateTimeKind.Unspecified).AddTicks(544), 4 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2015, 7, 12, 22, 6, 3, 292, DateTimeKind.Unspecified).AddTicks(362), 8 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "OrderId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OrderId", "Quantity" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 3, 3, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 2, 3, 1 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "BookId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 8, 3, 3, 5 },
                    { 9, 2, 4, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Stroman Group");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Spencer Group");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "O'Hara, Mertz and White");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Weber, Shields and Spencer");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Nasir.Franecki67@gmail.com", false, "Jasen.Ullrich" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Kamren41@yahoo.com", "Estevan.Krajcik" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Boyd.Konopelski@yahoo.com", "Ona40" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Shaun.Kessler@hotmail.com", "Lula.Ullrich39" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Jeanne_Legros@gmail.com", "Bo_Labadie" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Hassie.Swaniawski34@yahoo.com", "Connor60" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Eusebio28@hotmail.com", false, "Romaine.Schmitt46" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Enid.Yundt76@hotmail.com", "Mireille31" });
        }
    }
}
