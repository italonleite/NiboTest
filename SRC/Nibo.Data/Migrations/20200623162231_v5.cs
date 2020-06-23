using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nibo.Data.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAME",
                table: "BankStatements");

            migrationBuilder.DropColumn(
                name: "DTEND",
                table: "BankStatements");

            migrationBuilder.DropColumn(
                name: "DTSTART",
                table: "BankStatements");

            migrationBuilder.RenameColumn(
                name: "TRNTYPE",
                table: "Transactions",
                newName: "Trntype");

            migrationBuilder.RenameColumn(
                name: "DTPOSTED",
                table: "Transactions",
                newName: "Dtposted");

            migrationBuilder.RenameColumn(
                name: "MEMO",
                table: "Transactions",
                newName: "Memo");

            migrationBuilder.RenameColumn(
                name: "TRNAMT",
                table: "Transactions",
                newName: "Trnamt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Trnamt",
                table: "Transactions",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trntype",
                table: "Transactions",
                newName: "TRNTYPE");

            migrationBuilder.RenameColumn(
                name: "Dtposted",
                table: "Transactions",
                newName: "DTPOSTED");

            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "Transactions",
                newName: "MEMO");

            migrationBuilder.RenameColumn(
                name: "Trnamt",
                table: "Transactions",
                newName: "TRNAMT");

            migrationBuilder.AlterColumn<decimal>(
                name: "TRNAMT",
                table: "Transactions",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "BankStatements",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DTEND",
                table: "BankStatements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DTSTART",
                table: "BankStatements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
