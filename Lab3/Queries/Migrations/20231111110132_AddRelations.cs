using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Queries.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_WaiterId",
                table: "Customers",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Waiters_WaiterId",
                table: "Customers",
                column: "WaiterId",
                principalTable: "Waiters",
                principalColumn: "WaiterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Waiters_WaiterId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_WaiterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Customers");
        }
    }
}
