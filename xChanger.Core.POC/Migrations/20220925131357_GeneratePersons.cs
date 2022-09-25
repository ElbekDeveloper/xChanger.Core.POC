using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xChanger.Core.POC.Migrations
{
    public partial class GeneratePersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PersonId",
                table: "Pets",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_PersonId",
                table: "Pets",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_PersonId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PersonId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Pets");
        }
    }
}
