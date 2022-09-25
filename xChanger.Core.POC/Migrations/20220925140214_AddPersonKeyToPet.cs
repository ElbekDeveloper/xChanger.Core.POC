using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xChanger.Core.POC.Migrations
{
    public partial class AddPersonKeyToPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_PersonId",
                table: "Pets");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_PersonId",
                table: "Pets",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_PersonId",
                table: "Pets");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_PersonId",
                table: "Pets",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
