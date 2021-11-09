using Microsoft.EntityFrameworkCore.Migrations;

namespace Monets.Api.Migrations
{
    public partial class addon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Korisnik_KorisnickiRacunId",
                table: "Klijent");

            migrationBuilder.DropForeignKey(
                name: "FK_Transakcija_Korisnik_KorisnikId",
                table: "Transakcija");

            migrationBuilder.DropForeignKey(
                name: "FK_Uposlenik_Korisnik_KorisnickiRacunId",
                table: "Uposlenik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik");

            migrationBuilder.RenameTable(
                name: "Korisnik",
                newName: "KorisnickiRacun");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnickiRacun",
                table: "KorisnickiRacun",
                column: "KorisnickiRacunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_KorisnickiRacun_KorisnickiRacunId",
                table: "Klijent",
                column: "KorisnickiRacunId",
                principalTable: "KorisnickiRacun",
                principalColumn: "KorisnickiRacunId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transakcija_KorisnickiRacun_KorisnikId",
                table: "Transakcija",
                column: "KorisnikId",
                principalTable: "KorisnickiRacun",
                principalColumn: "KorisnickiRacunId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uposlenik_KorisnickiRacun_KorisnickiRacunId",
                table: "Uposlenik",
                column: "KorisnickiRacunId",
                principalTable: "KorisnickiRacun",
                principalColumn: "KorisnickiRacunId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_KorisnickiRacun_KorisnickiRacunId",
                table: "Klijent");

            migrationBuilder.DropForeignKey(
                name: "FK_Transakcija_KorisnickiRacun_KorisnikId",
                table: "Transakcija");

            migrationBuilder.DropForeignKey(
                name: "FK_Uposlenik_KorisnickiRacun_KorisnickiRacunId",
                table: "Uposlenik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnickiRacun",
                table: "KorisnickiRacun");

            migrationBuilder.RenameTable(
                name: "KorisnickiRacun",
                newName: "Korisnik");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik",
                column: "KorisnickiRacunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Korisnik_KorisnickiRacunId",
                table: "Klijent",
                column: "KorisnickiRacunId",
                principalTable: "Korisnik",
                principalColumn: "KorisnickiRacunId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transakcija_Korisnik_KorisnikId",
                table: "Transakcija",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnickiRacunId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uposlenik_Korisnik_KorisnickiRacunId",
                table: "Uposlenik",
                column: "KorisnickiRacunId",
                principalTable: "Korisnik",
                principalColumn: "KorisnickiRacunId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
