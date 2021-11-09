using Microsoft.EntityFrameworkCore.Migrations;

namespace Monets.Api.Migrations
{
    public partial class gradis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Grad_GradId",
                table: "Klijent");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikUloga_Uloga_UlogaId",
                table: "KorisnikUloga");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikUloga_Uposlenik_UposlenikId",
                table: "KorisnikUloga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnikUloga",
                table: "KorisnikUloga");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Uloga");

            migrationBuilder.RenameTable(
                name: "KorisnikUloga",
                newName: "UposlenikUloga");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikUloga_UposlenikId",
                table: "UposlenikUloga",
                newName: "IX_UposlenikUloga_UposlenikId");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikUloga_UlogaId",
                table: "UposlenikUloga",
                newName: "IX_UposlenikUloga_UlogaId");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Rejting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "GradId",
                table: "Klijent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Jelo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UposlenikId",
                table: "UposlenikUloga",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UlogaId",
                table: "UposlenikUloga",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UposlenikUloga",
                table: "UposlenikUloga",
                column: "UposlenikUlogaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Grad_GradId",
                table: "Klijent",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "GradId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UposlenikUloga_Uloga_UlogaId",
                table: "UposlenikUloga",
                column: "UlogaId",
                principalTable: "Uloga",
                principalColumn: "UlogaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UposlenikUloga_Uposlenik_UposlenikId",
                table: "UposlenikUloga",
                column: "UposlenikId",
                principalTable: "Uposlenik",
                principalColumn: "UposlenikId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Grad_GradId",
                table: "Klijent");

            migrationBuilder.DropForeignKey(
                name: "FK_UposlenikUloga_Uloga_UlogaId",
                table: "UposlenikUloga");

            migrationBuilder.DropForeignKey(
                name: "FK_UposlenikUloga_Uposlenik_UposlenikId",
                table: "UposlenikUloga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UposlenikUloga",
                table: "UposlenikUloga");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Jelo");

            migrationBuilder.RenameTable(
                name: "UposlenikUloga",
                newName: "KorisnikUloga");

            migrationBuilder.RenameIndex(
                name: "IX_UposlenikUloga_UposlenikId",
                table: "KorisnikUloga",
                newName: "IX_KorisnikUloga_UposlenikId");

            migrationBuilder.RenameIndex(
                name: "IX_UposlenikUloga_UlogaId",
                table: "KorisnikUloga",
                newName: "IX_KorisnikUloga_UlogaId");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Uloga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradId",
                table: "Klijent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UposlenikId",
                table: "KorisnikUloga",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UlogaId",
                table: "KorisnikUloga",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnikUloga",
                table: "KorisnikUloga",
                column: "UposlenikUlogaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Grad_GradId",
                table: "Klijent",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "GradId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikUloga_Uloga_UlogaId",
                table: "KorisnikUloga",
                column: "UlogaId",
                principalTable: "Uloga",
                principalColumn: "UlogaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikUloga_Uposlenik_UposlenikId",
                table: "KorisnikUloga",
                column: "UposlenikId",
                principalTable: "Uposlenik",
                principalColumn: "UposlenikId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
