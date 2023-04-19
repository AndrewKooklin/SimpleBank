using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBank.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepositAccounts",
                columns: table => new
                {
                    DepositAccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(nullable: false),
                    DepositTotal = table.Column<int>(nullable: false),
                    DateDepositOpen = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositAccounts", x => x.DepositAccountId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAccounts",
                columns: table => new
                {
                    SalaryAccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(nullable: false),
                    SalaryTotal = table.Column<int>(nullable: false),
                    DateSalaryOpen = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAccounts", x => x.SalaryAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    FathersName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_DepositAccounts_PersonId",
                        column: x => x.PersonId,
                        principalTable: "DepositAccounts",
                        principalColumn: "DepositAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_SalaryAccounts_PersonId",
                        column: x => x.PersonId,
                        principalTable: "SalaryAccounts",
                        principalColumn: "SalaryAccountId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "DepositAccounts");

            migrationBuilder.DropTable(
                name: "SalaryAccounts");
        }
    }
}
