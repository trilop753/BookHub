using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RecreateWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Rosario", "Sporer" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Damaris", "Haag" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Rosalyn", "Schulist" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Shanna", "Fadel" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Woodrow", "Thompson" }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[]
                {
                    "AuthorId",
                    "Description",
                    "ISBN",
                    "Price",
                    "PublisherId",
                    "Title",
                },
                values: new object[]
                {
                    2,
                    "Voluptas cumque quae et ut vel unde. Dolores impedit non deleniti possimus odit illum molestiae ut. Placeat sequi nam magnam velit. Non fugit reiciendis. Officiis dolor cum doloribus nulla eaque inventore sed voluptate et.",
                    "1686322064044",
                    8.32m,
                    2,
                    "Voluptate voluptas debitis sit.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[]
                {
                    "Illum ea blanditiis possimus voluptatibus rerum corrupti temporibus quis. Doloremque sapiente ullam. Voluptate eveniet placeat minus voluptatem voluptas qui ut. Sapiente dolore non dolore a magnam dolore.",
                    "0582325371671",
                    17.15m,
                    3,
                    "Mollitia atque nobis dolor.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[]
                {
                    5,
                    "Exercitationem eaque autem laudantium. Consequuntur ipsa voluptates natus illo occaecati perferendis molestias placeat. Fuga eius est sequi similique alias quas voluptas aut ut. Recusandae iste neque ab.",
                    "4861959228251",
                    16.26m,
                    "Asperiores dolorum velit explicabo.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[]
                {
                    3,
                    "Et voluptas asperiores et. Est ut sapiente iure vel perferendis impedit tempore voluptatem. Soluta cupiditate et eos maiores. Quidem optio cum iure dolorem eaque officia quibusdam.",
                    "3895470133207",
                    14.74m,
                    "Tempore facilis sed optio nam.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Schimmel and Sons"
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Green, Zemlak and Bartoletti"
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Walsh - Ward"
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Auer Inc"
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Edyth70@hotmail.com", true, "Misael.Kuhic94" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Cassandra98@hotmail.com", "Cordell.Stamm26" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Fermin_Murazik@hotmail.com", "Berta_Ernser69" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Michelle38@hotmail.com", "Florencio_King35" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Imani_Smith73@hotmail.com", "Velma_Kling60" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Brandyn.Moore@yahoo.com", false, "Lacey.King" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Marcelo52@hotmail.com", "Henderson_Bradtke10" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Megane35@yahoo.com", "Collin60" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Annamarie", "Bradtke" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Daphne", "Cole" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Maye", "Koch" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Eleazar", "Cormier" }
            );

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Carter", "Ullrich" }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Laborum et sint et labore aperiam at vero fuga.", 3, 2, 2 }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Rerum occaecati pariatur sequi dolor quia dolores harum eaque.",
                    4,
                    4,
                    2,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Laboriosam consectetur debitis ad nam id mollitia sequi architecto assumenda.",
                    4,
                    5,
                    7,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Nihil qui sint quis eum architecto cum animi.", 4, 2, 6 }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[]
                {
                    "Cumque possimus alias voluptatum soluta et saepe nulla.",
                    4,
                    8,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Et mollitia est et ut dignissimos deserunt rerum cumque et.",
                    4,
                    2,
                    8,
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[]
                {
                    "AuthorId",
                    "Description",
                    "ISBN",
                    "Price",
                    "PublisherId",
                    "Title",
                },
                values: new object[]
                {
                    5,
                    "Eos voluptatem et excepturi ipsa adipisci ipsum enim commodi. Quae qui animi harum quo. Omnis est odio delectus beatae ipsa aut optio corrupti. Reiciendis et repudiandae voluptates repellendus et consequatur dolores.",
                    "5135211071138",
                    16.79m,
                    3,
                    "Laborum ut labore voluptatibus aut placeat.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[]
                {
                    "Impedit ipsum pariatur omnis qui eum maiores dolor est in. Labore illum velit sit illo. Consectetur et vel. Eaque qui et repellendus eius repudiandae delectus.",
                    "8406788313011",
                    19.67m,
                    4,
                    "Eos autem illum nihil officiis.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[]
                {
                    1,
                    "Libero molestiae ratione aut ut velit est excepturi et earum. Enim id et. Velit quod ut excepturi vitae adipisci eligendi aut. Neque aspernatur repellendus quaerat quia est est deleniti suscipit. Eius modi fugiat.",
                    "2567661167988",
                    9.65m,
                    "Accusantium debitis assumenda qui esse et.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[]
                {
                    5,
                    "Hic recusandae qui officiis ut sint. Corrupti perferendis error velit. Reiciendis sunt quisquam molestiae corporis provident. Repudiandae cum doloribus quo reprehenderit quia ut iste.",
                    "6171119231525",
                    10.29m,
                    "Autem error vel in sit.",
                }
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Corwin - Crooks"
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Hirthe - Funk"
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Maggio, Thompson and Lehner"
            );

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Goodwin, Cartwright and Harber"
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Onie.Bauch@hotmail.com", false, "Bethany25" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Leonel.Gaylord10@hotmail.com", "Abdiel84" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Natalie.Hilll@yahoo.com", "Jaeden.Pfeffer" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Jadyn51@yahoo.com", "Zelda_Stracke" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Jermain.Dickens@gmail.com", "Carmel43" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Jean_Schoen@gmail.com", true, "Aylin.Langworth" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Oma85@yahoo.com", "Cristobal30" }
            );

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Leila.Stark12@gmail.com", "Elise.OConnell" }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Omnis corporis pariatur consequuntur autem asperiores eveniet deserunt facilis.",
                    4,
                    3,
                    5,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Distinctio vitae voluptates dicta tempora et et mollitia.",
                    1,
                    3,
                    1,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Fugiat dolorum optio maiores sint consequatur commodi quas nostrum velit.",
                    3,
                    3,
                    6,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Voluptatem iusto eaque beatae commodi excepturi impedit sed.",
                    2,
                    1,
                    7,
                }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Nam aut veniam odio est quasi est blanditiis quos.", 2, 1 }
            );

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[]
                {
                    "Quia eveniet quia debitis accusantium nulla officia exercitationem.",
                    2,
                    3,
                    5,
                }
            );
        }
    }
}
