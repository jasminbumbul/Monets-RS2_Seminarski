using Microsoft.EntityFrameworkCore.Migrations;

namespace Monets.Api.Migrations
{
    public partial class grad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Grad_GradId",
                table: "Klijent");

            migrationBuilder.DropIndex(
                name: "IX_Klijent_GradId",
                table: "Klijent");

            migrationBuilder.DropColumn(
                name: "GradId",
                table: "Klijent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradId",
                table: "Klijent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_GradId",
                table: "Klijent",
                column: "GradId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Grad_GradId",
                table: "Klijent",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "GradId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
