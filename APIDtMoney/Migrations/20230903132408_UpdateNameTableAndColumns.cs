using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDtMoney.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameTableAndColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Bills",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Bills",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Bills",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Bills",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Bills",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bills",
                newName: "BillId");
        }
    }
}
