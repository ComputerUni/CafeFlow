using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeFlow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_iscustomizable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCustomizable",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCustomizable",
                table: "Products");
        }
    }
}
