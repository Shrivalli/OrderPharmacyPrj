using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class MailOrderProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefillOrderLineItem",
                columns: table => new
                {
                    Policy_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Subscription_ID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefillOrderLineItem", x => x.Policy_ID);
                });

            migrationBuilder.CreateTable(
                name: "refillOrders",
                columns: table => new
                {
                    RefillOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subscription_ID = table.Column<int>(type: "int", nullable: false),
                    DrugID = table.Column<int>(type: "int", nullable: false),
                    RefillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextRefillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Policy_ID = table.Column<int>(type: "int", nullable: false),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefillOrderLinePolicy_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refillOrders", x => x.RefillOrderId);
                    table.ForeignKey(
                        name: "FK_refillOrders_RefillOrderLineItem_RefillOrderLinePolicy_ID",
                        column: x => x.RefillOrderLinePolicy_ID,
                        principalTable: "RefillOrderLineItem",
                        principalColumn: "Policy_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_refillOrders_RefillOrderLinePolicy_ID",
                table: "refillOrders",
                column: "RefillOrderLinePolicy_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refillOrders");

            migrationBuilder.DropTable(
                name: "RefillOrderLineItem");
        }
    }
}
