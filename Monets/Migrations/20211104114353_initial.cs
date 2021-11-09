using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monets.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnickiRacunId);
                });

            migrationBuilder.CreateTable(
                name: "Meni",
                columns: table => new
                {
                    MeniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meni", x => x.MeniId);
                });

            migrationBuilder.CreateTable(
                name: "Stol",
                columns: table => new
                {
                    StolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivStola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojMjesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stol", x => x.StolId);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Jelo",
                columns: table => new
                {
                    JeloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivJela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrijemeIzradeUminutama = table.Column<int>(type: "int", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: true),
                    KategorijaId = table.Column<int>(type: "int", nullable: true),
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jelo", x => x.JeloId);
                    table.ForeignKey(
                        name: "FK_Jelo_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    GradId = table.Column<int>(type: "int", nullable: false),
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentId);
                    table.ForeignKey(
                        name: "FK_Klijent_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijent_Korisnik_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnickiRacunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    UposlenikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    GradId = table.Column<int>(type: "int", nullable: false),
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.UposlenikId);
                    table.ForeignKey(
                        name: "FK_Uposlenik_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uposlenik_Korisnik_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnickiRacunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JeloMeni",
                columns: table => new
                {
                    JeloMeniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JeloId = table.Column<int>(type: "int", nullable: true),
                    MeniId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeloMeni", x => x.JeloMeniId);
                    table.ForeignKey(
                        name: "FK_JeloMeni_Jelo_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jelo",
                        principalColumn: "JeloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JeloMeni_Meni_MeniId",
                        column: x => x.MeniId,
                        principalTable: "Meni",
                        principalColumn: "MeniId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rejting",
                columns: table => new
                {
                    RejtingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<double>(type: "float", nullable: true),
                    JeloId = table.Column<int>(type: "int", nullable: false),
                    KlijentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rejting", x => x.RejtingId);
                    table.ForeignKey(
                        name: "FK_Rejting_Jelo_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jelo",
                        principalColumn: "JeloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rejting_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Potvrdjena = table.Column<bool>(type: "bit", nullable: true),
                    Placena = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StolId = table.Column<int>(type: "int", nullable: false),
                    KlijentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Stol_StolId",
                        column: x => x.StolId,
                        principalTable: "Stol",
                        principalColumn: "StolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    UposlenikUlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(type: "int", nullable: true),
                    UlogaId = table.Column<int>(type: "int", nullable: true),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => x.UposlenikUlogaId);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Uloga_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JeloRezervacija",
                columns: table => new
                {
                    JeloRezervacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JeloId = table.Column<int>(type: "int", nullable: false),
                    RezervacijaId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeloRezervacija", x => x.JeloRezervacijaId);
                    table.ForeignKey(
                        name: "FK_JeloRezervacija_Jelo_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jelo",
                        principalColumn: "JeloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JeloRezervacija_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transakcija",
                columns: table => new
                {
                    TransakcijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Šifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RezervacijaId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.TransakcijaId);
                    table.ForeignKey(
                        name: "FK_Transakcija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnickiRacunId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transakcija_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jelo_KategorijaId",
                table: "Jelo",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_JeloMeni_JeloId",
                table: "JeloMeni",
                column: "JeloId");

            migrationBuilder.CreateIndex(
                name: "IX_JeloMeni_MeniId",
                table: "JeloMeni",
                column: "MeniId");

            migrationBuilder.CreateIndex(
                name: "IX_JeloRezervacija_JeloId",
                table: "JeloRezervacija",
                column: "JeloId");

            migrationBuilder.CreateIndex(
                name: "IX_JeloRezervacija_RezervacijaId",
                table: "JeloRezervacija",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_GradId",
                table: "Klijent",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_KorisnickiRacunId",
                table: "Klijent",
                column: "KorisnickiRacunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaId",
                table: "KorisnikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UposlenikId",
                table: "KorisnikUloga",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rejting_JeloId",
                table: "Rejting",
                column: "JeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Rejting_KlijentId",
                table: "Rejting",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KlijentId",
                table: "Rezervacija",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_StolId",
                table: "Rezervacija",
                column: "StolId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_KorisnikId",
                table: "Transakcija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_RezervacijaId",
                table: "Transakcija",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_GradId",
                table: "Uposlenik",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_KorisnickiRacunId",
                table: "Uposlenik",
                column: "KorisnickiRacunId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeloMeni");

            migrationBuilder.DropTable(
                name: "JeloRezervacija");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "Rejting");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "Meni");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "Jelo");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Stol");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
