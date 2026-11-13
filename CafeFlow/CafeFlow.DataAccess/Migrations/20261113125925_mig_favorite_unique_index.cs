using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeFlow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_favorite_unique_index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_CustomerId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_CustomerId_ProductId",
                table: "Favorites",
                columns: new[] { "CustomerId", "ProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_CustomerId_ProductId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_CustomerId",
                table: "Favorites",
                column: "CustomerId");
        }
    }
}
