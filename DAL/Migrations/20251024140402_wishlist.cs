using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class wishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "WishlistItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_UserId1",
                table: "WishlistItem",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItem_User_UserId1",
                table: "WishlistItem",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItem_User_UserId1",
                table: "WishlistItem");

            migrationBuilder.DropIndex(
                name: "IX_WishlistItem_UserId1",
                table: "WishlistItem");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WishlistItem");
        }
    }
}
