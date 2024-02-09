using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softline_API.Migrations
{
    public partial class initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Status_ID = table.Column<Guid>(nullable: false),
                    Status_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goal_Status_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "Status",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Status_ID",
                table: "Goal",
                column: "Status_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
