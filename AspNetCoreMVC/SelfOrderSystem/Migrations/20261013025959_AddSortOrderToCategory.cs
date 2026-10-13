using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSortOrderToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortOder",
                table: "Categories",
                newName: "SortOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "Categories",
                newName: "SortOder");
        }
    }
}
