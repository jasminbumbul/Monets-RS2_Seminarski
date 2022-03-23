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
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiRacun",
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
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    PassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassCodeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiRacun", x => x.KorisnickiRacunId);
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
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    OpisJela = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false),
                    GradId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Klijent_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
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
                        name: "FK_Uposlenik_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
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
                name: "Favorit",
                columns: table => new
                {
                    FavoritId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JeloId = table.Column<int>(type: "int", nullable: true),
                    KlijentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorit", x => x.FavoritId);
                    table.ForeignKey(
                        name: "FK_Favorit_Jelo_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jelo",
                        principalColumn: "JeloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorit_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId",
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
                    KlijentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
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
                    PocetakRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StolId = table.Column<int>(type: "int", nullable: false),
                    KlijentId = table.Column<int>(type: "int", nullable: false),
                    KrajRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    PotvrdjenaKlijent = table.Column<bool>(type: "bit", nullable: true),
                    OnlinePlacanje = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
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
                name: "UposlenikUloga",
                columns: table => new
                {
                    UposlenikUlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikUloga", x => x.UposlenikUlogaId);
                    table.ForeignKey(
                        name: "FK_UposlenikUloga_Uloga_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UposlenikUloga_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikId",
                        onDelete: ReferentialAction.Cascade);
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
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RezervacijaId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    Iznos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.TransakcijaId);
                    table.ForeignKey(
                        name: "FK_Transakcija_KorisnickiRacun_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "KorisnickiRacunId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transakcija_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradId", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sarajevo" },
                    { 2, "Mostar" },
                    { 3, "Bugojno" },
                    { 4, "Gornji Vakuf" },
                    { 5, "Tuzla" },
                    { 6, "Zenica" },
                    { 7, "Bihać" }
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "KategorijaId", "Naziv", "Slika", "SlikaPutanja" },
                values: new object[,]
                {
                    { 4, "Piće", null, null },
                    { 3, "Čorbe i supe", null, null },
                    { 2, "Pize", null, null },
                    { 1, "Pite", null, null }
                });

            migrationBuilder.InsertData(
                table: "KorisnickiRacun",
                columns: new[] { "KorisnickiRacunId", "Adresa", "DatumIzmjene", "DatumKreiranja", "DatumRodjenja", "Email", "EmailVerified", "GUID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "PassCode", "Prezime", "SlikaPutanja", "Status", "Telefon" },
                values: new object[,]
                {
                    { 15, "Adresa BB", new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 500, DateTimeKind.Local).AddTicks(759), new DateTime(1995, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent6@monets.com", true, null, "Klijent6", "klijent6", "H0TO/cRIMrniNFJUe0u+9Ls41p8=", "pZ4VUkhxIededW9Kc3fddg==", null, "Korisnik6", "mobile_user.jpg", true, "061-223-122" },
                    { 14, "Adresa BB", new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 500, DateTimeKind.Local).AddTicks(640), new DateTime(1998, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent5@monets.com", true, null, "Klijent5", "klijent5", "QEQrhazJUNiGnYVHFvjYPVX/WBc=", "21OCmfOlTijJcieRKyAXbw==", null, "Korisnik5", "mobile_user.jpg", true, "061-923-922" },
                    { 13, "Adresa BB", new DateTime(2021, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 500, DateTimeKind.Local).AddTicks(512), new DateTime(1998, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent4@monets.com", true, null, "Klijent4", "klijent4", "Z/vTSFN446ZSfMS6fGG8a7Qvurk=", "5L8210XRbNLR5aj/XvZjVw==", null, "Korisnik4", "mobile_user.jpg", false, "061-923-922" },
                    { 12, "Adresa BB", new DateTime(2021, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 500, DateTimeKind.Local).AddTicks(343), new DateTime(1995, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent3@monets.com", true, null, "Klijent3", "klijent3", "EsJLe8ee+4dgyKJUDi/tXfTtvWE=", "K3YgAqOo6sXU3jnaKd6SFQ==", null, "Korisnik3", "mobile_user.jpg", false, "061-923-922" },
                    { 11, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 500, DateTimeKind.Local).AddTicks(223), new DateTime(1992, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent2@monets.com", true, null, "Klijent2", "klijent2", "owQgZM0cEZMsciL2CRYWr+5X7qs=", "a3cQviRyeCgqiWn2sq1A3Q==", null, "Korisnik2", "mobile_user.jpg", true, "061-123-966" },
                    { 10, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 500, DateTimeKind.Local).AddTicks(98), new DateTime(2001, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent1@monets.com", true, null, "Klijent1", "klijent1", "C1daKmDRANJY52Ih19R3QX7jWl4=", "1Zl7xqcgZyDplUTh3csTeA==", null, "Korisnik1", "mobile_user.jpg", true, "061-123-966" },
                    { 9, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9977), new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent@monets.com", true, null, "Klijent", "Klijent", "MF3VXhPbX/tf8zBGXrI4Zy6iuIQ=", "A6FukNww20nJAf9cXQXNWg==", null, "Korisnik", "mobile_user.jpg", true, "063-223-666" },
                    { 6, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9507), new DateTime(1999, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik5@monets.com", true, null, "Uposlenik5", "uposlenik5", "SjIH/XkGbYk+nOtRTYPcAGn+3Lw=", "+wPOEh+N8vXpOK3PNHzv4w==", null, "Korisnik5", "profile_pic.png", false, "063-423-444" },
                    { 7, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9632), new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik6@monets.com", true, null, "Uposlenik6", "uposlenik6", "K3WikWreNg+w5swRFJMp4GHEgPE=", "tbVMmvSm1EOPk+1ZX0RJ1Q==", null, "Korisnik6", "profile_pic.png", false, "062-223-666" },
                    { 5, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9370), new DateTime(1989, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik4@monets.com", true, null, "Uposlenik4", "uposlenik4", "UypY0GQnL/SUo5dyJydtU1DiMp4=", "A7IYE205DtUmy7QsKkzEZQ==", null, "Korisnik4", "profile_pic.png", true, "063-123-323" },
                    { 4, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9211), new DateTime(1982, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik3@monets.com", true, null, "Uposlenik3", "uposlenik2", "wEYPqmvwIZ5gUETZeqjA8ybC+VY=", "FcwMYHeHRkNpAx638FXRTQ==", null, "Korisnik3", "profile_pic.png", true, "062-333-333" },
                    { 3, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9018), new DateTime(1985, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik2@monets.com", true, null, "Uposlenik2", "uposlenik2", "/ovmGwQelyw11/5+dI4JpdsVguA=", "mHim+MW7WLrdlB5F4ZTmfQ==", null, "Korisnik2", "profile_pic.png", true, "061-111-4444" },
                    { 2, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(8029), new DateTime(1995, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik1@monets.com", true, null, "Uposlenik1", "uposlenik1", "Ah36GzWPtu55I6y4PBFtmqca4UE=", "80vnxV8y5AcNOogcg1sbTg==", null, "Korisnik", "profile_pic.png", true, "061-111-333" },
                    { 1, "Adresa BB", new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 492, DateTimeKind.Local).AddTicks(6092), new DateTime(1991, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop@monets.com", true, null, "Desktop", "desktop", "dW/jDfpjrrtsT2jBb4LBd6swn/I=", "Hu7Udq6AaxndW09xVRVW8g==", null, "Korisnik", "profile_pic.png", true, "061-222-333" },
                    { 8, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 22, 39, 56, 499, DateTimeKind.Local).AddTicks(9850), new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile@monets.com", true, null, "Mobile", "mobile", "+LdEe8+yalXMf5Lw62XmR4fWL2k=", "RucNZd9aLzKbyI3mtQiLqA==", null, "Korisnik", "mobile_user.jpg", true, "062-223-666" }
                });

            migrationBuilder.InsertData(
                table: "Stol",
                columns: new[] { "StolId", "BrojMjesta", "NazivStola" },
                values: new object[,]
                {
                    { 1, 2, "Stol br. 1" },
                    { 2, 3, "Stol br. 2" },
                    { 3, 4, "Stol br. 3" },
                    { 4, 4, "Stol br. 4" },
                    { 5, 4, "Stol br. 5" }
                });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "UlogaId", "Naziv" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Uposlenik" }
                });

            migrationBuilder.InsertData(
                table: "Jelo",
                columns: new[] { "JeloId", "Cijena", "KategorijaId", "NazivJela", "OpisJela", "SlikaPutanja", "Status", "VrijemeIzradeUminutama" },
                values: new object[,]
                {
                    { 1, 10.0, 1, "Burek", "Burek je jelo od razvučenog tijesta sa mesom", "burek.png", true, 10 },
                    { 20, 5.0, 4, "Schweppes", "Osvježavajuće bezalkoholno piće", "drink.png", true, 10 },
                    { 19, 5.0, 4, "Orangina", "Osvježavajuće bezalkoholno piće od narandže", "drink.png", true, 10 },
                    { 18, 2.0, 4, "Mineralna voda", "Mineralna voda", "drink.png", true, 10 },
                    { 16, 3.0, 4, "Pepsi", "Klasični pepsi", "drink.png", true, 10 },
                    { 15, 3.0, 4, "Fanta", "Klasična Fanta", "drink.png", true, 10 },
                    { 14, 3.0, 4, "Coca Cola", "Klasična Coca Cola", "drink.png", true, 10 },
                    { 22, 2.0, 3, "Pileća supa", "Supa od piletine", "supa.png", true, 10 },
                    { 13, 3.0, 3, "Goveđa supa", "Supa od govedine", "supa.png", true, 10 },
                    { 12, 6.0, 3, "Grah", "Tradicionalni grah sa sudžukom", "supa.png", true, 10 },
                    { 17, 3.0, 4, "Cockta", "Klasična Cockta", "drink.png", true, 10 },
                    { 10, 12.0, 2, "Funghi ", "Pizza sa umakom od paradajza, kačkavalj, šampinjoni, ljute papričice", "pizza.png", true, 10 },
                    { 9, 15.0, 2, "Pizza četiri sira", "Pizza od 4 sira: mocarela, straćino, fontina, gorgonzola", "pizza.png", true, 10 },
                    { 8, 12.0, 2, "Piza - 4 god. doba", "Sastojci : paradajz, mocarela, gljive, školjke, rakovi, paprika, crne masline, maslinovo ulje, limunov sok", "pizza.png", true, 10 },
                    { 7, 11.0, 2, "Capricosa", "Pizza sa paradaz-pireom, gaudom, šampinjonima i maslinama", "pizza.png", true, 10 },
                    { 6, 10.0, 2, "Margarita", "Klasična pizza oljuštenim paradajzom i mocarelom", "pizza.png", true, 10 },
                    { 5, 9.0, 1, "Tirit", "Tirit je jelo od razvučenog tijesta sa piletinom", "burek.png", true, 10 },
                    { 4, 7.0, 1, "Krompiruša", "Krompiruša je jelo od razvučenog tijesta sa krompirom", "burek.png", true, 10 },
                    { 3, 7.0, 1, "Zeljanica", "Zeljanica je jelo od razvučenog tijesta sa zeljom", "burek.png", true, 10 },
                    { 2, 8.0, 1, "Sirnica", "Sirnica je jelo od razvučenog tijesta sa sirom", "burek.png", true, 10 },
                    { 11, 12.0, 2, "Funghi ", "Pizza sa umakom od paradajza, kačkavalj, šampinjoni, ljute papričice", "pizza.png", true, 10 }
                });

            migrationBuilder.InsertData(
                table: "Klijent",
                columns: new[] { "KlijentId", "GradId", "KorisnickiRacunId", "Status" },
                values: new object[,]
                {
                    { 6, 1, 13, false },
                    { 5, 1, 12, false },
                    { 4, 1, 11, true },
                    { 3, 1, 10, true },
                    { 2, 1, 9, true },
                    { 1, 1, 8, true },
                    { 8, 1, 15, true },
                    { 7, 1, 14, true }
                });

            migrationBuilder.InsertData(
                table: "Uposlenik",
                columns: new[] { "UposlenikId", "DatumZaposlenja", "GradId", "KorisnickiRacunId", "Status" },
                values: new object[,]
                {
                    { 6, new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, false },
                    { 5, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, true },
                    { 4, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, true },
                    { 2, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, true },
                    { 1, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, true },
                    { 7, new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, false },
                    { 3, new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, true }
                });

            migrationBuilder.InsertData(
                table: "Rejting",
                columns: new[] { "RejtingId", "JeloId", "KlijentId", "Ocjena" },
                values: new object[,]
                {
                    { 6, 5, 6, 4.5 },
                    { 18, 17, 3, 4.5 },
                    { 19, 18, 2, 4.5 },
                    { 2, 1, 2, 4.0 },
                    { 17, 16, 4, 4.5 },
                    { 12, 11, 6, 4.5 },
                    { 14, 13, 6, 4.5 },
                    { 13, 12, 5, 4.5 },
                    { 10, 9, 8, 4.5 },
                    { 3, 2, 3, 4.0 },
                    { 21, 20, 1, 4.5 },
                    { 1, 1, 1, 5.0 },
                    { 7, 6, 7, 4.5 },
                    { 11, 10, 7, 4.5 },
                    { 5, 4, 5, 4.5 },
                    { 4, 3, 4, 4.5 },
                    { 16, 15, 4, 4.5 },
                    { 8, 7, 8, 4.5 },
                    { 9, 8, 8, 4.5 },
                    { 20, 19, 1, 4.5 },
                    { 15, 14, 5, 4.5 }
                });

            migrationBuilder.InsertData(
                table: "Rezervacija",
                columns: new[] { "RezervacijaId", "DatumIzmjene", "DatumKreiranja", "KlijentId", "KrajRezervacije", "OnlinePlacanje", "Placena", "PocetakRezervacije", "Poruka", "Potvrdjena", "PotvrdjenaKlijent", "Sifra", "Status", "StolId" },
                values: new object[,]
                {
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "QTRTR0", true, 1 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "73SV5S", true, 2 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "EQ08WJ", true, 2 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "5THGH3", true, 1 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "8RYHRQ", true, 2 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "Z5IHL2", true, 3 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "9B25IJ", true, 4 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "RY36FB", true, 4 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "NB1VEP", true, 2 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "EQ5ZEG", true, 2 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "Y3YIG8", true, 2 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "CQECIJ", true, 3 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "SLK1NH", true, 1 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "KT5VPS", true, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "ZN60PV", true, 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "03JGTT", true, 2 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, true, true, "DL4B5V", true, 3 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "P3PCGQ", true, 1 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "2VMPTI", true, 3 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "15M2KM", true, 3 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "OKQXUQ", true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rezervacija",
                columns: new[] { "RezervacijaId", "DatumIzmjene", "DatumKreiranja", "KlijentId", "KrajRezervacije", "OnlinePlacanje", "Placena", "PocetakRezervacije", "Poruka", "Potvrdjena", "PotvrdjenaKlijent", "Sifra", "Status", "StolId" },
                values: new object[,]
                {
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "5OXX3D", true, 2 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), null, false, false, "KPJQ9X", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "UposlenikUloga",
                columns: new[] { "UposlenikUlogaId", "DatumIzmjene", "UlogaId", "UposlenikId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 7, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 6, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 5, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 4, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 3, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 2, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 1, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "JeloRezervacija",
                columns: new[] { "JeloRezervacijaId", "JeloId", "Kolicina", "RezervacijaId" },
                values: new object[,]
                {
                    { 1, 1, 4, 1 },
                    { 35, 15, 2, 8 },
                    { 28, 7, 1, 15 },
                    { 17, 12, 3, 9 },
                    { 18, 7, 1, 9 },
                    { 19, 2, 2, 9 },
                    { 32, 19, 2, 19 },
                    { 20, 9, 2, 10 },
                    { 16, 15, 2, 8 },
                    { 21, 2, 2, 10 },
                    { 22, 11, 6, 11 },
                    { 23, 18, 2, 11 },
                    { 30, 1, 1, 17 },
                    { 24, 11, 2, 12 },
                    { 25, 1, 2, 12 },
                    { 29, 9, 1, 16 },
                    { 26, 3, 1, 13 },
                    { 31, 12, 2, 18 },
                    { 15, 2, 2, 7 },
                    { 27, 7, 1, 14 },
                    { 33, 19, 2, 20 },
                    { 34, 19, 2, 21 },
                    { 6, 7, 1, 3 },
                    { 14, 7, 2, 7 },
                    { 7, 8, 1, 3 },
                    { 5, 5, 1, 2 },
                    { 9, 16, 2, 4 },
                    { 8, 15, 4, 4 },
                    { 10, 2, 2, 5 },
                    { 11, 3, 3, 5 },
                    { 2, 12, 3, 1 },
                    { 12, 3, 3, 6 },
                    { 13, 5, 3, 6 },
                    { 3, 13, 2, 1 },
                    { 4, 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Transakcija",
                columns: new[] { "TransakcijaId", "Datum", "Iznos", "KorisnikId", "RezervacijaId", "Sifra", "Status" },
                values: new object[,]
                {
                    { 25, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 16, "DNXUMV", true },
                    { 26, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 16, "ALZ90K", true },
                    { 27, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 4, 16, "UDQO0L", true },
                    { 24, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 15, "G1FFMN", true },
                    { 28, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 4, 16, "11TRCY", true },
                    { 30, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 4, 17, "H9TJR8", true },
                    { 29, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 4, 17, "KRKM91", true }
                });

            migrationBuilder.InsertData(
                table: "Transakcija",
                columns: new[] { "TransakcijaId", "Datum", "Iznos", "KorisnikId", "RezervacijaId", "Sifra", "Status" },
                values: new object[,]
                {
                    { 31, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 5, 18, "6X1SJQ", true },
                    { 32, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 5, 18, "0R6Q2J", true },
                    { 37, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 7, 20, "SIKH1S", true },
                    { 36, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 7, 20, "U03W69", true },
                    { 35, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 6, 20, "4NN0NV", true },
                    { 34, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 6, 19, "R3SOHC", true },
                    { 38, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 8, 21, "RBXVGE", true },
                    { 33, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 5, 19, "1PJOP0", true },
                    { 14, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 11, "UVAZ8E", true },
                    { 22, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 13, "7719OZ", true },
                    { 1, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 1, 1, "U3KUJU", true },
                    { 2, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 1, 2, "66HE3E", true },
                    { 3, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 1, 3, "K6LOLW", true },
                    { 4, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, 1, 4, "TINPAC", true },
                    { 5, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.0, 1, 5, "I1CR67", true },
                    { 6, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 1, 6, "1LXM5C", true },
                    { 7, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 1, 7, "ITS1PL", true },
                    { 8, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 8, "3XXHGG", true },
                    { 9, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 9, "S9F2QD", true },
                    { 10, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 10, "ORHO7H", true },
                    { 11, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 10, "939LHQ", true },
                    { 12, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 10, "B7BNT4", true },
                    { 13, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 10, "P7MFQ3", true },
                    { 39, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 8, 21, "KXBR44", true },
                    { 15, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 11, "CCJU4H", true },
                    { 16, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 12, "VL4AI1", true },
                    { 17, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 12, "3FFCHI", true },
                    { 18, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 12, "JYOQBC", true },
                    { 19, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 2, 12, "BAB54M", true },
                    { 20, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 12, "18V3OA", true },
                    { 21, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 13, "TL2HWU", true },
                    { 23, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 3, 14, "XA7MG2", true },
                    { 40, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 8, 21, "0NQ9W3", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorit_JeloId",
                table: "Favorit",
                column: "JeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorit_KlijentId",
                table: "Favorit",
                column: "KlijentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikUloga_UlogaId",
                table: "UposlenikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikUloga_UposlenikId",
                table: "UposlenikUloga",
                column: "UposlenikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorit");

            migrationBuilder.DropTable(
                name: "JeloMeni");

            migrationBuilder.DropTable(
                name: "JeloRezervacija");

            migrationBuilder.DropTable(
                name: "Rejting");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "UposlenikUloga");

            migrationBuilder.DropTable(
                name: "Meni");

            migrationBuilder.DropTable(
                name: "Jelo");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Stol");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiRacun");
        }
    }
}
