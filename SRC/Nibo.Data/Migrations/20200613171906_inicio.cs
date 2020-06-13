using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nibo.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankStatements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", nullable: true),
                    DTSTART = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTEND = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankStatements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    CODE = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SEVERITY = table.Column<string>(type: "VARCHAR(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankStatementId = table.Column<Guid>(nullable: false),
                    TRNTYPE = table.Column<string>(type: "varchar(10)", nullable: false),
                    DTPOSTED = table.Column<DateTime>(type: "datetime", nullable: false),
                    TRNAMT = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MEMO = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_BankStatements_BankStatementId",
                        column: x => x.BankStatementId,
                        principalTable: "BankStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignOn",
                columns: table => new
                {
                    SIGONID = table.Column<Guid>(nullable: false),
                    StatusCode = table.Column<int>(nullable: true),
                    DTSERVER = table.Column<DateTime>(type: "datetime", nullable: false),
                    LANGUAGE = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignOn", x => x.SIGONID);
                    table.ForeignKey(
                        name: "FK_SignOn_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SignOn_StatusCode",
                table: "SignOn",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankStatementId",
                table: "Transactions",
                column: "BankStatementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignOn");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "BankStatements");
        }
    }
}
