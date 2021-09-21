using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class MailOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refillOrders_RefillOrderLineItem_RefillOrderLinePolicy_ID",
                table: "refillOrders");

            migrationBuilder.DropTable(
                name: "RefillOrderLineItem");

            migrationBuilder.DropIndex(
                name: "IX_refillOrders_RefillOrderLinePolicy_ID",
                table: "refillOrders");

            migrationBuilder.DropColumn(
                name: "RefillOrderLinePolicy_ID",
                table: "refillOrders");

            migrationBuilder.RenameColumn(
                name: "RefillOrderId",
                table: "refillOrders",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "refillOrders",
                newName: "RefillOrderId");

            migrationBuilder.AddColumn<int>(
                name: "RefillOrderLinePolicy_ID",
                table: "refillOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RefillOrderLineItem",
                columns: table => new
                {
                    Policy_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Subscription_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefillOrderLineItem", x => x.Policy_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_refillOrders_RefillOrderLinePolicy_ID",
                table: "refillOrders",
                column: "RefillOrderLinePolicy_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_refillOrders_RefillOrderLineItem_RefillOrderLinePolicy_ID",
                table: "refillOrders",
                column: "RefillOrderLinePolicy_ID",
                principalTable: "RefillOrderLineItem",
                principalColumn: "Policy_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
