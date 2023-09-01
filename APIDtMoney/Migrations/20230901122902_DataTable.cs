using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDtMoney.Migrations
{
    /// <inheritdoc />
    public partial class DataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Bills (Type, Description, Value, Category, Date) Values('Income', 'Desenvolvimento de site', 12.00000, 'Venda', getdate())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Bills");
        }
    }
}
