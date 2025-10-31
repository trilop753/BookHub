using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.WebMVC.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class identity_db_context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalIdentityUsers_User_UserId",
                table: "LocalIdentityUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalIdentityUsers",
                table: "LocalIdentityUsers");

            migrationBuilder.RenameTable(
                name: "LocalIdentityUsers",
                newName: "AspNetUsers");

            migrationBuilder.RenameIndex(
                name: "IX_LocalIdentityUsers_UserId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Glenda", "King" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Emiliano", "Upton" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Owen", "Koelpin" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Paige", "Christiansen" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Aric", "Carroll" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { "Alias delectus qui iusto minima consequuntur voluptatem. Quod quasi ducimus. Ex quas rem eum. Quisquam quod repellat in nesciunt quisquam harum quaerat molestiae incidunt. Soluta veritatis ea illo deleniti ipsam. Alias in debitis pariatur est minima deleniti cum expedita tenetur.", "4437910626772", 11.17m, 2, "Velit quo incidunt ut atque aspernatur." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 5, "Quia ea exercitationem quas quos. Autem nihil qui veniam. Cupiditate quo et mollitia. Non ipsum aperiam non aut. Et nisi qui. Nihil omnis exercitationem earum tempora.", "5485993829794", 13.02m, 1, "Explicabo architecto omnis consequatur." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 2, "Accusantium non facere repellat dolores non molestiae voluptates ipsum. Eos ut ducimus laborum distinctio voluptas. Qui itaque rerum officia dolore. Consequatur nobis odio aperiam molestiae.", "9006657375233", 12.78m, 2, "Ea commodi totam qui corrupti." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[] { 1, "Dignissimos modi sequi doloribus. Odit non sit quos. Qui non quia temporibus rem ut doloremque provident nihil ab. Aut aspernatur laudantium blanditiis.", "3391457047746", 9.75m, "Ad aut et eaque." });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Voluptate hic quisquam et molestiae et dignissimos delectus necessitatibus et.", 3, 3, 4 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Earum ipsum labore quas maxime in quis enim repudiandae dignissimos.", 2, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Non magnam non qui ut ipsum modi qui consequatur harum.", 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Nulla unde voluptatum rem nihil voluptas porro natus officia.", 3, 3 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Doloribus nihil blanditiis possimus dolores illo illo quia consequatur dolores.", 2, 5, 2 });

            migrationBuilder.UpdateData(
                table: "BookReview",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Body", "BookId", "Stars", "UserId" },
                values: new object[] { "Quia quam delectus ut nisi sit adipisci aut.", 2, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 1, 4, 3 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 3, 8 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 2, 8 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 2, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2015, 10, 21, 18, 59, 35, 331, DateTimeKind.Unspecified).AddTicks(9366), 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2016, 4, 11, 4, 11, 33, 541, DateTimeKind.Unspecified).AddTicks(19), 7 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 8, 27, 7, 5, 8, 941, DateTimeKind.Unspecified).AddTicks(3258), 8 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 9, 15, 56, 11, 625, DateTimeKind.Unspecified).AddTicks(9238), 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 2, 1, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrderId", "Quantity" },
                values: new object[] { 2, 2 });

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
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Towne, Sauer and Howell");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Denesik and Sons");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Emard, Swift and Satterfield");

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Keebler - Kreiger");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Percival.Schowalter@hotmail.com", "Art_Wuckert" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Cory_Glover@yahoo.com", "Bertha_Ullrich" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Carmelo_Bradtke@hotmail.com", "Laurine.Kling" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Username" },
                values: new object[] { "German_Russel@yahoo.com", "Otho.Nader58" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Elmira_Morar7@yahoo.com", true, "Favian_Haag46" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Camilla_Ferry70@yahoo.com", "Brooks.Pfeffer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Username" },
                values: new object[] { "Alessia_Stanton@gmail.com", "Gillian_Goyette" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "IsBanned", "Username" },
                values: new object[] { "Rosalind_Steuber@hotmail.com", false, "Shanie.Miller" });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_User_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_User_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "LocalIdentityUsers");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UserId",
                table: "LocalIdentityUsers",
                newName: "IX_LocalIdentityUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalIdentityUsers",
                table: "LocalIdentityUsers",
                column: "Id");

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
                columns: new[] { "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { "Earum voluptas magni est nulla illum ut occaecati. Necessitatibus explicabo vitae delectus expedita dolorem delectus. Qui non sint quidem accusantium perspiciatis. Magni libero unde consequatur magnam reprehenderit. Ut delectus sapiente voluptas eum praesentium iure.", "5066116065970", 7.32m, 4, "Architecto et est et ipsa autem." });

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
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[] { 1, "Enim incidunt voluptates autem. Voluptas placeat sit sed quibusdam quis quisquam ea dolorem. Fugit et vel. Vero veniam nulla unde dolore.", "7950073956229", 12.65m, 1, "Nulla animi voluptate id." });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Description", "ISBN", "Price", "Title" },
                values: new object[] { 5, "Voluptatibus eaque consequatur voluptatibus est. Non perspiciatis corporis saepe suscipit reiciendis omnis. Est incidunt eos rem delectus ea sequi non. Et quo ipsa quis. Sunt mollitia fugiat molestiae optio dolorum. Et corrupti ab tenetur velit commodi eligendi modi.", "7465822066895", 7.05m, "Laboriosam voluptas et est." });

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
                columns: new[] { "Body", "Stars", "UserId" },
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
                columns: new[] { "Body", "Stars", "UserId" },
                values: new object[] { "Quia at facilis ut non maiores ex mollitia.", 4, 5 });

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
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 3, 5, 2 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Quantity", "UserId" },
                values: new object[] { 4, 5, 1 });

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
                keyValue: 2,
                columns: new[] { "BookId", "OrderId", "Quantity" },
                values: new object[] { 3, 2, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 4, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrderId", "Quantity" },
                values: new object[] { 3, 1 });

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
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookId", "Quantity" },
                values: new object[] { 1, 3 });

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
                columns: new[] { "Email", "Username" },
                values: new object[] { "Pattie_Langosh70@hotmail.com", "Kiara.Ebert" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_LocalIdentityUsers_User_UserId",
                table: "LocalIdentityUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
